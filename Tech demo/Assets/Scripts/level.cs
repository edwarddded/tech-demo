using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        int level = Random.Range(1, 4);
        if (level == 1)
        {
            SceneManager.LoadSceneAsync(1);
           
        }
        else if (level == 2)
        {
            SceneManager.LoadSceneAsync(2);
          
        }
        else
        {
            SceneManager.LoadSceneAsync(3);
           
        }
    }
    
}

