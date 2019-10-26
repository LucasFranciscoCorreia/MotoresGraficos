using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private string level;
    public Animator fade;

    public void FadeToLevel(string level)
    {
        this.level = level;
        fade.SetTrigger("Fade");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(level);
    }
}
