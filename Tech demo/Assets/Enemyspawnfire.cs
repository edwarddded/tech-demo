using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawnfire : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public float MiniX;
    public float MaxX;
    Vector2 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(1, 4);
        float randx = Random.Range(MiniX, MaxX);
        Debug.Log(random);
        whereToSpawn = new Vector2(randx, transform.position.y);
        if (random == 1)
        {
            Instantiate(Enemy1, whereToSpawn, Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
