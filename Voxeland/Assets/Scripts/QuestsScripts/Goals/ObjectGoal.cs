using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectGoal : Goal
{
    public Item required;

    public override bool HasCompleted()
    {
        Debug.Log("Completing");
        if (Inventory.instance.items.Contains(required))
        {
            isCompleted = true;
            Debug.Log("Objective Completed");
        }

        return isCompleted;
    }
}
