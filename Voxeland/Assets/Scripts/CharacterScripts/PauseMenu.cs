using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;

    public GameObject pauseObject;
    public CursorScript cursor;
    public GameObject inventoryMenu;
    public GameObject equipmentMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pause Menu") && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseObject.SetActive(true);
            cursor.ShowCursor();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(false);
        isPaused = false;
        inventoryMenu.SetActive(false);
        equipmentMenu.SetActive(false);
    }

    public void Inventory()
    {
        inventoryMenu.SetActive(!inventoryMenu.activeSelf);
    }

    public void Equipment()
    {
        equipmentMenu.SetActive(!equipmentMenu.activeSelf);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
