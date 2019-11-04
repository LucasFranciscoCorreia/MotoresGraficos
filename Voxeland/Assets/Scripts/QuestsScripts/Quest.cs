using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public string title = "New Quest";
    public string description;

    public NPC npc;
    public Dialogue newDialogue;

    public Goal goal;
    public Quest nextQuest;

    public virtual void Finish()
    {
        if(goal.isCompleted && npc != null && newDialogue != null)
        {
            npc.dialog = newDialogue;
            npc.giveQuest = nextQuest;
            Destroy(this);
        }
    }

}
