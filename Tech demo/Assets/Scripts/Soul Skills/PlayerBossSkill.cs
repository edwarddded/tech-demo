using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBossSkill : MonoBehaviour
{
    public Image imageCooldown;

    private bool isCooldown = false;
    private float cooldownDuration = 15f;
    private float cooldownTimer;

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
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownDuration;

            // Insert boss skill here

        }
    }
}
