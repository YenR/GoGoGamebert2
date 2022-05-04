using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public dialogue d;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(d);
    }
}
