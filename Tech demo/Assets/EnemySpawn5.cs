using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn5 : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    int random;

    float randX;

    Vector2 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 4);
        randX = Random.Range(170, 172f);

        Debug.Log(random);

        if (random == 1)
        {
            Enemy1.GetComponent<Enemy>().PositionMin = 166f;
            Enemy1.GetComponent<Enemy>().PositionMax = 178f;
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy1, whereToSpawn, Quaternion.identity);
        }
        if (random == 2)
        {
            Enemy2.GetComponent<Enemy>().PositionMin = 166f;
            Enemy2.GetComponent<Enemy>().PositionMax = 178f;
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy2, whereToSpawn, Quaternion.identity);
        }
        if (random == 3)
        {
            Enemy3.GetComponent<Enemy>().PositionMin = 166f;
            Enemy3.GetComponent<Enemy>().PositionMax = 178f;
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy3, whereToSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
