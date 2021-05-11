using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulPickup : MonoBehaviour
{
    private SoulInventory soulInventory;

    public GameObject abilityIcon;
    public int skillIndexNumber;

    void Start()
    {
        soulInventory = GameObject.FindWithTag("Player").GetComponent<SoulInventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i < soulInventory.abilitySlots; i++)
            {
                if(soulInventory.abilityIndex[i] == skillIndexNumber)
                {
                    // If ability exists and slot is full, item will not be picked up
                    if (soulInventory.isFull[i] == true) {
                        Debug.Log("Cannot hold anymore of this ability");
                        break;
                    }
                    else if(soulInventory.isFull[i] == false)
                    {
                        Debug.Log("Adding extra use for this ability");
                        soulInventory.abilityCharges[i] += 1;

                        // Update value of skill uses in the HUD
                        soulInventory.skillChargesTxt[i].text = soulInventory.abilityCharges[i].ToString();

                        Destroy(gameObject);
                        Debug.Log("Slot number: " + i + " Ability Charges: " + soulInventory.abilityCharges[i]);
                        
                        // Sets the skill slot to full once capacity is reached
                        if(soulInventory.abilityCharges[i] >= 3)
                        {
                            Debug.Log("Capacity for this ability reached");
                            soulInventory.isFull[i] = true;
                            break;
                        }
                    }

                    break;
                }

                // If there is an available slot and the player is not currently carrying the skill, attempt to add new skill
                Debug.Log("Currently at ability slot " + i);
                Debug.Log("Attempting to add new ability");
                if(soulInventory.isFull[i] == false && soulInventory.abilityIndex[i] == 0)
                {
                    // Creates icon for the skill in the specified empty slot
                    soulInventory.uiIcons[i] = (GameObject)Instantiate(abilityIcon, soulInventory.uiSlots[i].transform, false);

                    Debug.Log("Adding new ability");
                    soulInventory.abilityIndex[i] = skillIndexNumber;
                    soulInventory.abilityCharges[i] = 1;
                    Debug.Log("Slot number: " + i + " Ability Charges: " + soulInventory.abilityCharges[i]);

                    //Update value of skill uses in the HUD
                    soulInventory.skillChargesTxt[i].text = soulInventory.abilityCharges[i].ToString();

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
