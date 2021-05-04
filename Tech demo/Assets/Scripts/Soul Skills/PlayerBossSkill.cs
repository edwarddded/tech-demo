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
    private bool skillAvailable = true;
    private int currentlySelectedSkill = 1;

    //Boss skill prefabs
    public GameObject ForestLaserArm; 

    void Start()
    {
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UseAbility();
        }

        if (isCooldown)
        {
            ApplyCooldown();
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
        else if(skillAvailable)
        {
            isCooldown = true;
            cooldownTimer = cooldownDuration;
            UseCurrentlySelectedSkill();
        }
    }

    private void UseCurrentlySelectedSkill()
    {
        if(currentlySelectedSkill == 1)
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
    }
}
