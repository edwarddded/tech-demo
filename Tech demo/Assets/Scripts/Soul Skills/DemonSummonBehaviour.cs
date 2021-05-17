using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSummonBehaviour : MonoBehaviour
{
    bool isAttacking;
    public GameObject fireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        for(int i = 1; i < 6; i++)
        {
            int rotation = Random.Range(0, 359);
            Instantiate(fireballPrefab, this.transform.position, Quaternion.Euler(0, 0, rotation));
            rotation = Random.Range(0, 359);
            Instantiate(fireballPrefab, this.transform.position, Quaternion.Euler(0, 0, rotation));
            rotation = Random.Range(0, 359);
            Instantiate(fireballPrefab, this.transform.position, Quaternion.Euler(0, 0, rotation));
            rotation = Random.Range(0, 359);
            Instantiate(fireballPrefab, this.transform.position, Quaternion.Euler(0, 0, rotation));
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }
}
