using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] Faces;
    public Sprite back;
    public GameObject[] cards;
    public Text match;

	private bool _initialized = false;
    private int remainMatches = 5;

    // Update is called once per frame
    void Update () {
        print("update...");
        
        if (!_initialized)
        {
            List<int> shown = new List<int>();
            int randomIndex;
            for (int i = 0; i < 10; i++)
            {
                //shuffle the cards
                randomIndex = Random.Range(0, 10);
                print(randomIndex);
                while (shown.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, 10);
                    print(randomIndex);
                }
                cards[randomIndex].GetComponent<Card>().cardValue = i + 1;
                cards[randomIndex].GetComponent<Card>().initialized = true;
                shown.Add(randomIndex);
            }

            foreach (GameObject card in cards)
                print("++::: " + card.GetComponent<Card>().cardValue);

            foreach (GameObject card in cards)
                card.GetComponent<Card>().setupGraphics();

            if (!_initialized)
                _initialized = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            print("botton down");
            checkCards();
        }
    }

    public Sprite getBackPicture()
    {
        return back;
    }

    public Sprite getFacePicture(int i)
    {
        return Faces[(i - 1) % 5];
    }

    private void checkCards()
    {
        List<int> c = new List<int>();
        for(int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == Card.FACE_STATE)
                c.Add(i);
        }

        //if exactlly 2 cards are flipped
        if(c.Count == 2)
        {
            Card.NOT_FLIP = true;
            int x = Card.BACK_STATE;
            int c1 = c[0];
            int c2 = c[1];
            if(cards[c1].GetComponent<Card>().cardValue % 5 == cards[c2].GetComponent<Card>().cardValue % 5)
            {
                x = 2; //neither the back of face state
                remainMatches--;
                match.text = "Number of Matches: " + remainMatches;
                if(remainMatches == 0)
                {
                    //reset game and load the "endscene"
                    _initialized = false;
                    Card.NOT_FLIP = false;
                    remainMatches = 5;
                    SceneManager.LoadScene("EndScene");
                }
            }

            //Let player get a glimpse of the false pairs
            for (int i = 0; i < c.Count; i++)
            {
                cards[c[i]].GetComponent<Card>().state = x;
                cards[c[i]].GetComponent<Card>().checkFalse();
            }
        }
    }
}
