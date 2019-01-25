using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Text dialogueContinue;
    private GameObject dialoguePanel;
    private bool isActiveDialogue = false;
    private int pressedKeys;
    private Sentence[] currentDialogSentences;
    Sentence activeSentence = null;
    private bool relation;

    private Queue<Sentence> sentences;

    public void Awake()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialoguePanel.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        sentences = new Queue<Sentence>();

	}
	
	public void StartDialogue (Dialouge dialouge)
    {
        dialoguePanel.SetActive(true);
        //Copy sentences from dialog
        currentDialogSentences = dialouge.sentences.ToArray();
        nameText.text = dialouge.characterName;
        foreach (Sentence sentence in currentDialogSentences) {
            sentences.Enqueue(sentence);
        }
        if (sentences.Count > 0)
        {
            dialogueContinue.text = "Continue... [E]";
        }
        if (!isActiveDialogue) {
            DisplayNextSentence();
        }
        isActiveDialogue = true;
    }

    public void DisplayNextSentence()
    {
        //Get relation between keys in current sentence in dialog
        if (sentences.Count > 1)
        {
            dialogueContinue.text = "Continue... [E]";
        }
        if (sentences.Count == 1)
        {
            dialogueContinue.text = "End. [E]";
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        activeSentence = sentences.Dequeue();
        dialogueText.text = activeSentence.text;
        relation = activeSentence.relation;
    }

    private void Update()
    {
        if (isActiveDialogue && activeSentence != null)
        {
            //Check if E key was pressed
            if (Input.GetKeyDown("e"))
            { 
                DisplayNextSentence();
            }
            //Check if all required keys were pressed - and relation
            if (relation)
            {
                if (activeSentence.endingKeys.Count != 0)
                {
                    for (int i = 0; i < activeSentence.endingKeys.Count; i++)
                    {
                        if (activeSentence.endingKeys[i] != null)
                        {
                            if (Input.GetKeyDown(activeSentence.endingKeys[i]))
                            {
                                activeSentence.endingKeys[i] = null;
                                pressedKeys++;
                                if (pressedKeys == activeSentence.endingKeys.Count)
                                {
                                    DisplayNextSentence();
                                    pressedKeys = 0;
                                }
                            }
                        }
                    }
                }
            }
            //Check if any from required keys was pressed - xor relation
            if (!relation)
            {
                if (activeSentence.endingKeys.Count != 0)
                {
                    for (int i = 0; i < activeSentence.endingKeys.Count; i++)
                    {
                        if (Input.GetKeyDown(activeSentence.endingKeys[i]))
                        {
                            DisplayNextSentence();
                        }
                    }
                }
            }
        }
    }

    public void EndDialogue()
    {
        isActiveDialogue = false;
        sentences.Clear();
        dialoguePanel.SetActive(false);
        currentDialogSentences = null;
        pressedKeys = 0;
    }
}