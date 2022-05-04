using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Canvas canvas;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        //canvas.enabled = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(dialogue d)
    {
        //Debug.Log("starting conversation with " + d.name);

        nameText.text = d.name;

        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        //GameObject.Find("Player").GetComponent<shooting>().enabled = false;

        sentences.Clear();

        foreach(string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        animator.SetBool("isOpen", true);
        //canvas.enabled = true;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
        //Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        //Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
        //canvas.enabled = false;
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        //GameObject.Find("Player").GetComponent<shooting>().enabled = true;
    }

}
