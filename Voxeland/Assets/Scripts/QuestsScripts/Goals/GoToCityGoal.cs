using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCityGoal : Goal
{
    public string scene;

    public override bool HasCompleted()
    {
        this.isCompleted = true;
        Debug.Log("Objective Completed");
        GoToScene();
        return isCompleted;
    }

    public void GoToScene()
    {
        //FindObjectOfType<LevelChanger>().FadeToLevel(scene);
        SceneManager.LoadScene(scene);
    }
}
