using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MemuManager : MonoBehaviour {
    public void trigMenuEvent(int i)
    {
        switch (i) {
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
