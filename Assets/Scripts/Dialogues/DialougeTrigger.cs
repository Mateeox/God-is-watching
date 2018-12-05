using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour {

    public Dialouge dialouge;
    private bool visited = false;

    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialouge);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && visited == false)
        {
            TriggerDialouge();
            visited = true;
        }
    }
}
