using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
}
