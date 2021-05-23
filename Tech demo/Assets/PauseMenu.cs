using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
     GameObject canvas;
     GameObject cam;
     GameObject CM;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        canvas = GameObject.Find("Canvas").gameObject;
        cam = GameObject.Find("Main Camera").gameObject;
        CM = GameObject.Find("CM vcam1").gameObject;
        Player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
                isPaused = true;
            }
            else
            {
                ResumeGame();
                isPaused = false;
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GotoMainMenu()
    {
        GameObject BGM = GameObject.Find("BGM").gameObject;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Destroy(BGM);
        Destroy(canvas);
        Destroy(cam);
        Destroy(Player);
        Destroy(CM);
        Destroy(gameObject);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
