using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    public bool isCompleted;

    public int countNeeded;
    public int countCurrent;

    public void Increment(int ammount)
    {
        countCurrent = Mathf.Min(countCurrent + ammount, countNeeded);
        HasCompleted();
    }

    public virtual bool HasCompleted()
    {
        if(countCurrent >= countNeeded)
        {
            isCompleted = true;
            Debug.Log("Objective Completed");
        }

        return isCompleted;
    }
    
}
