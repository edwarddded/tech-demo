using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject Fill, Border, text, heart;

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Boss1")
        {
            Fill.SetActive(true);
            Border.SetActive(true);
            text.SetActive(true);
            heart.SetActive(true);
        }
        else
        {
            Fill.SetActive(false);
            Border.SetActive(false);
            text.SetActive(false);
            heart.SetActive(false);
        }
    }
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
