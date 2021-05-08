using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void Load()
    {

        SceneManager.LoadSceneAsync(1);
    }
 
    
}

