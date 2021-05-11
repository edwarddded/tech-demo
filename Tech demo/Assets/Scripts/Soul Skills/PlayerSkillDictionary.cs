using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillDictionary : MonoBehaviour
{
    public Transform firepoint;

    public GameObject iceShotPrefab;
    public GameObject combustPrefab;
    public GameObject flyingEyeSummonPrefab;
    public GameObject mushroomBombPrefab;
    public GameObject goblinDaggerPrefab;
    public GameObject greenFireballPrefab;
    public GameObject skeletonGuardianPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateAbility(int abilityIndex) {

        if (abilityIndex == 1)
            IceShot();
        if (abilityIndex == 2)
            Combust();
        if (abilityIndex == 3)
            FlyingEyeSummon();
        if (abilityIndex == 4)
            MushroomBomb();
        if (abilityIndex == 5)
            StartCoroutine("GoblinDaggerFan");
        if (abilityIndex == 6)
            StartCoroutine("FireballSpread");
        if (abilityIndex == 7)
            SkeletonGuardian();
    }

    //Below is the collection of all the player skills

    // #1 Ice Shot
    void IceShot()
    {
        Debug.Log("Ability 1 Ice Shot Activated");
        Instantiate(iceShotPrefab, firepoint.position, firepoint.rotation);
    }

    // #2 
    void Combust()
    {
        Debug.Log("Ability 2 Combust Activated");

        Instantiate(combustPrefab, this.transform.position, this.transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                Enemy enemy = colliders[i].gameObject.GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.TakeDamage(3f);
                }
            }
        }
       
    }

    void FlyingEyeSummon()
    {
        Debug.Log("Ability 3 Flying Eye Summon Activated");
        Instantiate(flyingEyeSummonPrefab, this.transform.position + new Vector3(0,2,0), firepoint.rotation);
    }

    void MushroomBomb()
    {
        Debug.Log("Ability 4 Mushroom Bomb Activated");
        Instantiate(mushroomBombPrefab, firepoint.position, firepoint.rotation);
    }

    IEnumerator GoblinDaggerFan()
    {
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 45));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 135));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 225));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 270));
        yield return new WaitForSeconds(0.15f);
        Instantiate(goblinDaggerPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 315));
    }

    IEnumerator FireballSpread()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(greenFireballPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 40));
            Instantiate(greenFireballPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 20));
            Instantiate(greenFireballPrefab, firepoint.position, firepoint.rotation);
            Instantiate(greenFireballPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 340));
            Instantiate(greenFireballPrefab, firepoint.position, firepoint.rotation * Quaternion.Euler(0, 0, 320));
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SkeletonGuardian()
    {
        var skeletonGuardian = Instantiate(skeletonGuardianPrefab, firepoint.position + new Vector3(0, 2.2f, 0), firepoint.rotation);
        skeletonGuardian.transform.parent = gameObject.transform;
    }
}
