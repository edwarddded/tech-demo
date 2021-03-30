using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    private SoulInventory soulInventory;
    public int skillIndexNumber;

    void Start()
    {
        soulInventory = GameObject.FindWithTag("Player").GetComponent<SoulInventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i < soulInventory.abilitySlots-1; i++)
            {
                if(soulInventory.abilityIndex[i] == skillIndexNumber)
                {
                    if (soulInventory.isFull[i] == true) {
                        Debug.Log("Cannot hold anymore of this ability");
                        break;
                    }
                    else if(soulInventory.isFull[i] == false)
                    {
                        Debug.Log("Adding extra use for this ability");
                        soulInventory.abilityCharges[i] += 1;
                        Destroy(gameObject);
                        Debug.Log("Slot number: " + i + " Ability Charges: " + soulInventory.abilityCharges[i]);
                        

                        if(soulInventory.abilityCharges[i] >= 3)
                        {
                            Debug.Log("Capacity for this ability reached");
                            soulInventory.isFull[i] = true;
                            break;
                        }
                    }

                    break;
                }

                Debug.Log("Currently at ability slot " + i);
                Debug.Log("Attempting to add new ability");
                if(soulInventory.isFull[i] == false && soulInventory.abilityIndex[i] == 0)
                {
                    Debug.Log("Adding new ability");
                    soulInventory.abilityIndex[i] = skillIndexNumber;
                    soulInventory.abilityCharges[i] = 1;
                    Debug.Log("Slot number: " + i + " Ability Charges: " + soulInventory.abilityCharges[i]);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
