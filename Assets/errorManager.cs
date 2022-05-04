using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class errorManager : MonoBehaviour
{
    public static errorManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TMP_Text txt;
    public Animator errorAnim;

    public void updateText(string newText)
    {
        txt.SetText(newText);
        errorAnim.SetTrigger("show");
    }
}
