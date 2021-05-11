using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void Play()
    {

        SceneManager.LoadSceneAsync(2);
    }
    public void PlayLevel2()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void Options()
    {

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}

