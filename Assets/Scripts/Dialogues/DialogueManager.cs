using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Text dialogueContinue;
    private GameObject dialoguePanel;

    private Queue<string> sentences;

    public void Awake()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialoguePanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
	}
	
	public void StartDialogue (Dialouge dialouge)
    {
        dialoguePanel.SetActive(true);
        nameText.text = dialouge.characterName;
        sentences.Clear();
        foreach (string sentence in dialouge.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        dialogueContinue.text = "Continue... [E]";
        if (sentences.Count == 1)
        {
            dialogueContinue.text = "End. [E]";
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
