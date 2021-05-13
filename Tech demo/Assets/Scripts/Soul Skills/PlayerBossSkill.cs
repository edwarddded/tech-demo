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

    //Boss skill prefabs
    public GameObject ForestLaserArm; 

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
                StartCoroutine((SwapActiveSkill));
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

        }

        else if(currentlySelectedSkill == 3 && hasIceSkill)
        {

        }

    }

    private IEnumerator SwapActiveSkill()
    {
        isSkillCycling = true;
        if (currentlySelectedSkill == 1 && hasForestSkill)
        {
            currentlySelectedSkill = 2;
        }
        if (currentlySelectedSkill == 2 && hasFireSkill)
        {
            currentlySelectedSkill = 3;
        }
        if (currentlySelectedSkill == 3 && hasIceSkill)
        {
            currentlySelectedSkill = 1;
        }

        yield return new WaitForSeconds(0.5f);
        isSkillCycling = false;
    }

    private void UpdateIcon()
    {
        if(currentlySelectedSkill == 1 && hasForestSkill)
        {
            forestSkillImage.enabled = true;
            // Disable the other two images
        }
        if(currentlySelectedSkill == 2 && hasFireSkill)
        {

        }
        if(currentlySelectedSkill == 3 && hasIceSkill)
        {

        }
    }
}
