using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialog;
    public Transform chat;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialog);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            chat.gameObject.SetActive(true);
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
