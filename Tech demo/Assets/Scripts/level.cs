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

        SceneManager.LoadSceneAsync(1);
    }
    public void Options()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
 
    
}

