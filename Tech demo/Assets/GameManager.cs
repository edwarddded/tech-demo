using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enemyMovement EM;
    public GameObject Item;
    public GameObject enemy;
    bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Item.transform.position = new Vector2(0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (EM.health == 0)
        {
            if (spawned == false)
            {
                spawned = true;
                Instantiate(Item, Item.transform.position, Item.transform.rotation);
            }
           
        }
    }
}
