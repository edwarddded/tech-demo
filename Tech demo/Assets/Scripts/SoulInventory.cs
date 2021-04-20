using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulInventory : MonoBehaviour
{
    public PlayerSkillDictionary playerSkills;

    public bool[] isFull;
    public int abilitySlots;
    public int[] abilityCharges;
    public int[] abilityIndex;

    public GameObject[] uiSlots;
    public GameObject[] uiIcons;
    public Text[] skillChargesTxt;

    private int maxAbilityUses;

    // Start is called before the first frame update
    void Start()
    {
        maxAbilityUses = 3;

        abilitySlots = 4;
        isFull = new bool[4];
        abilityCharges = new int[4];
        abilityIndex = new int[4];

    }

    // Update is called once per frame
    void Update()
    {
        // Calls the UseSkill function which accesses the ability stored in the slot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Attempting to use slot 1");
            UseSkill(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Attempting to use slot 2");
            UseSkill(1);
        }
    }

    void UseSkill(int SlotNumber)
    {
        if (abilityIndex[SlotNumber] > 0 && abilityCharges[SlotNumber] > 0)
        {
            Debug.Log("Activating ability " + abilityIndex[SlotNumber]);
            abilityCharges[SlotNumber] -= 1;
            playerSkills.ActivateAbility(abilityIndex[SlotNumber]);

            // Update UI text
            skillChargesTxt[SlotNumber].text = abilityCharges[SlotNumber].ToString();

            if (abilityCharges[SlotNumber] < maxAbilityUses)
                isFull[SlotNumber] = false;

            if (abilityCharges[SlotNumber] <= 0)
            {
                abilityIndex[SlotNumber] = 0;
                Destroy(uiIcons[SlotNumber]);
            }
        }
        else
        {
            Debug.Log("Cannot activate ability. Ability slot is empty.");
        }
    }

    // Mostly using this method on game reset
    public void ClearInventory() { 

        for(int i = 0; i < abilitySlots-1; i++)
        {
            abilityIndex[i] = 0;
            abilityCharges[i] = 0;
            isFull[i] = false;
        }

    }
}
