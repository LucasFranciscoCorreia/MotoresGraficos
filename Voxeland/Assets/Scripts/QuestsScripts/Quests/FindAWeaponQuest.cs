using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAWeaponQuest : Quest
{

    public Equipment weapon;

    private void Awake()
    {
        goal = new ObjectGoal();
        ((ObjectGoal)goal).required = weapon;
    }
}
