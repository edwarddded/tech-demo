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
            UseSkill(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSkill(1);
        }
    }

    void UseSkill(int SlotNumber)
    {
        if (abilityIndex[SlotNumber] > 0 && abilityCharges[SlotNumber] > 0)
        {
            Debug.Log("Activating Skill " + abilityIndex[SlotNumber]);
            abilityCharges[SlotNumber] -= 1;
            playerSkills.ActivateAbility(abilityIndex[SlotNumber]);

            if (abilityCharges[SlotNumber] < 3)
                isFull[SlotNumber] = false;

            if (abilityCharges[SlotNumber] <= 0)
            {
                abilityIndex[SlotNumber] = 0;
            }
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
