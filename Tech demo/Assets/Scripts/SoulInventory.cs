using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulInventory : MonoBehaviour
{
    public PlayerSkillDictionary playerSkills;

    public bool[] isFull;
    public int abilitySlots;
    public int[] abilityCharges;
    public int[] abilityIndex;

    // Start is called before the first frame update
    void Start()
    {
        abilitySlots = 5;
        isFull = new bool[5];
        abilityCharges = new int[5];
        abilityIndex = new int[5];

        //For the sake of testing / tech demo, reseting inventory
        ClearInventory();
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

            if (abilityCharges[SlotNumber] < 3)
                isFull[SlotNumber] = false;

            if (abilityCharges[SlotNumber] <= 0)
            {
                abilityIndex[SlotNumber] = 0;
            }
        }
        else
        {
            Debug.Log("Cannot activate ability. Ability slot is empty.");
        }
    }

    // Mostly using this method on game reset
    public void ClearInventory() { 

        for(int i = 0; i < abilitySlots; i++)
        {
            abilityIndex[i] = 0;
            abilityCharges[i] = 0;
        }

    }
}
