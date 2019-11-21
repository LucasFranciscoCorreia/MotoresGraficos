using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpToVillageQuest : Quest
{
    public string village;

    private void Awake()
    {
        this.goal.isCompleted = true;
    }

    public override void Finish()
    {
        FindObjectOfType<LevelChanger>().FadeToLevel("Village");
    }
}
