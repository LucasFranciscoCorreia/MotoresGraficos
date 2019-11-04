using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Dialogue dialog;
    public Transform chat;

    public Quest giveQuest;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialog, giveQuest);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            chat.gameObject.SetActive(true);
            chat.GetComponentInChildren<Text>().text = "[F] to Chat";
            StartCoroutine(AwaitChat());
        }
    }

    IEnumerator AwaitChat()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                TriggerDialog();
                chat.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            chat.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}
