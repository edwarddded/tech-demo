using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillDictionary : MonoBehaviour
{

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
            Test2();
    }

    //Below is the collection of all the player skills

    // #1 Ice Shot
    void IceShot()
    {
        Debug.Log("Ability 1 Activated");
    }

    // #2 
    void Test2()
    {
        Debug.Log("Ability 2 Activated");
    }

}
