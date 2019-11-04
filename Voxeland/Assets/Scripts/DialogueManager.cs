using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text name;
    public Text message;
    public GameObject chat;
    public Animator anim;
    public Quest quest;

    public Queue<string> sentences;
    private CursorScript cursor;
    private CharacterScript character;
    

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
        cursor = FindObjectOfType<CursorScript>();
        character = FindObjectOfType<CharacterScript>();
    }

    public void StartDialogue(Dialogue dialog, Quest quest)
    {
        if (quest != null)
            Debug.Log("Preparing a quest");
        character.isTalking = true;
        cursor.ShowCursor();
        anim.SetBool("isOpen", true);
        sentences.Clear();
        name.text = dialog.name;
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        this.quest = quest;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        StopAllCoroutines();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Debug.Log("Awaiting dialog end");
        string text = sentences.Dequeue();
        StartCoroutine(TypeSentences(text));
    }

    IEnumerator TypeSentences(string sentence)
    {
        message.text = "";
        foreach(char letter  in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        chat.SetActive(true);
        cursor.HideCursor();
        character.isTalking = false;
        Debug.Log("Finishing quest delivery");
        if (quest != null)
        {
            Debug.Log("Delivering quest");
            FindObjectOfType<QuestManager>().AddQuest(quest);
            //quest = null;
        }
    }
}
