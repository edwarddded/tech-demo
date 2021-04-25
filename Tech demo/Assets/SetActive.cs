using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActive : MonoBehaviour
{
    public GameObject Healthbar;
    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if (sceneName == "Boss1")
        {
            Healthbar.SetActive(true);
        }
        else
        {
            Healthbar.SetActive(false);
        }
    }
}
