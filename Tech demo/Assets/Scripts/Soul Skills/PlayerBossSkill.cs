using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBossSkill : MonoBehaviour
{
    // Cooldown variables
    public Image imageCooldown;
    private bool isCooldown = false;
    private float cooldownDuration = 15f;
    private float cooldownTimer;

    //Boss skill variables
    public Transform firepoint;
    public bool skillAvailable = false;
    private int currentlySelectedSkill = 1;
    public bool hasForestSkill = false;
    public bool hasFireSkill = false;
    public bool hasIceSkill = false;
    private bool isSkillCycling = false;

    //Boss skill icons
    public Image forestSkillImage;
    public Image fireSkillImage;

    //Boss skill prefabs
    public GameObject ForestLaserArm;
    public GameObject demonSummonPrefab;

    void Start()
    {
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIcon();

        if (Input.GetKeyDown(KeyCode.T))
        {
            UseAbility();
        }

        if (isCooldown)
        {
            ApplyCooldown();
        }

        if (!isSkillCycling)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                StartCoroutine(SwapActiveSkill());
            }
        }


    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0.0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownDuration;
        }
    }

    public void UseAbility()
    {
        if (isCooldown)
        {
            
        }
        else if(skillAvailable && currentlySelectedSkill != 0)
        {
            isCooldown = true;
            cooldownTimer = cooldownDuration;
            UseCurrentlySelectedSkill();
        }
    }

    private void UseCurrentlySelectedSkill()
    {
        if(currentlySelectedSkill == 1 && hasForestSkill)
        {
            if(firepoint.rotation.eulerAngles.y == 180)
            {
                Instantiate(ForestLaserArm, new Vector3(transform.position.x + 5, transform.position.y - 2, transform.position.z), firepoint.rotation);
            }
            else
            {
                Instantiate(ForestLaserArm, new Vector3(transform.position.x - 5, transform.position.y - 2, transform.position.z), firepoint.rotation);
            }

        }

        else if(currentlySelectedSkill == 2 && hasFireSkill)
        {
            var demonSummon = Instantiate(demonSummonPrefab, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), firepoint.rotation);
            demonSummon.transform.parent = gameObject.transform;
        }

        else if(currentlySelectedSkill == 3 && hasIceSkill)
        {

        }

    }

    private IEnumerator SwapActiveSkill()
    {
        isSkillCycling = true;
        if (currentlySelectedSkill == 1 && hasFireSkill)
        {
            currentlySelectedSkill = 2;
        }
        else if (currentlySelectedSkill == 2 && hasIceSkill)
        {
            currentlySelectedSkill = 3;
        }
        else if(currentlySelectedSkill == 2)
        {
            currentlySelectedSkill = 1;
        }
        else if(currentlySelectedSkill == 3)
        {
            currentlySelectedSkill = 1;
        }



        yield return new WaitForSeconds(0.75f);
        isSkillCycling = false;
    }

    private void UpdateIcon()
    {
        if(currentlySelectedSkill == 1 && hasForestSkill)
        {
            forestSkillImage.enabled = true;
            fireSkillImage.enabled = false;
        }
        if(currentlySelectedSkill == 2 && hasFireSkill)
        {
            forestSkillImage.enabled = false;
            fireSkillImage.enabled = true;
        }
        if(currentlySelectedSkill == 3 && hasIceSkill)
        {
            forestSkillImage.enabled = false;
            fireSkillImage.enabled = false;
        }
    }
}
