using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDontdestroy : MonoBehaviour
{
    public GameObject canvas;
    public GameObject cam;
    public GameObject CM;
    // Start is called before the first frame update
    public void Awake()
    {
        canvas = GameObject.Find("Canvas");
        cam = GameObject.Find("Main Camera");
        CM = GameObject.Find("CM vcam1");
        DontDestroyOnLoad(cam);
        DontDestroyOnLoad(CM);
        DontDestroyOnLoad(canvas);
    }
}
