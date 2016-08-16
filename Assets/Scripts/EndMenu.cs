using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {

    public void trigMenuEvent(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("PlayingScene");
                break;
            case (1):
                Application.Quit();
                break;
        }
    }
}
