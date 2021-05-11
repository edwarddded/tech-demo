using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrack : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - Player.transform.position.x < 5 || this.transform.position.y < 9)
        {
            transform.Translate(0, -10 * Time.deltaTime, 0, Space.Self);
        }
    }
}
