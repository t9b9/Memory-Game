using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {

    public static int BACK_STATE = 0;
    public static int FACE_STATE = 1;

    public static bool NOT_FLIP = false;
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _back;
    private Sprite _face;

    private GameObject gameManager;

    void Start()
    {
        _state = BACK_STATE;
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
       _back = gameManager.GetComponent<GameManager>().getBackPicture();
       _face = gameManager.GetComponent<GameManager>().getFacePicture(_cardValue);
    }

    public void flip()
    {
        print("---------flip");
        print("!NOT_FLIP---------" + !NOT_FLIP);
        print("state---------" + state);
        if (!NOT_FLIP)
        {
            if (state == BACK_STATE)
            {
                state = FACE_STATE;
                GetComponent<Image>().sprite = _face;
            }
            else if (state == FACE_STATE)
            {
                state = BACK_STATE;
                GetComponent<Image>().sprite = _back;
            }
        }
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void checkFalse()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (state == BACK_STATE)
            GetComponent<Image>().sprite = _back;
        else if (state == FACE_STATE)
            GetComponent<Image>().sprite = _face;
        NOT_FLIP = false;
    }
}
