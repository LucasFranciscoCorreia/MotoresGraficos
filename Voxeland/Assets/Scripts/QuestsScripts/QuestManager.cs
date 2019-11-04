using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;

    private void Start()    {
        quests = new List<Quest>();
    }

    public void AddQuest(Quest newQuest)
    {
        Debug.Log("Receiving a quest");
        if (!quests.Contains(newQuest))
        {
            quests.Add(newQuest);
            Debug.Log("Received a quest named " + newQuest.title);
            newQuest.npc.giveQuest = null;
        }
    }

    private void Update()
    {
        foreach(var quest in quests)
        {
            if (quest.goal.isCompleted)
            {
                quest.Finish();
                quests.Remove(quest);
                quest.npc.giveQuest = quest.nextQuest;
                break;
            }
            else
            {
                quest.goal.HasCompleted();
            }
        }   
    }
}
