using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cycScript : MonoBehaviour
{
    public void raccClicked()
    {
        if (globalVars.raccUnlocked)
        {
            ll.LoadLevelByNr(5);
        }
        else
            err.PlayOneShot(err.clip);
    }


    public void retroClicked()
    {
        if (globalVars.retroUnlocked)
        {
            ll.LoadLevelByNr(4);
        }
        else
            err.PlayOneShot(err.clip);
    }

    public AudioSource err;
    public LevelLoader ll;
    public Button racc, retro;

    public Sprite rc, ret;

    public TMP_Text ract, rett;

    // Start is called before the first frame update
    void Start()
    {
        if(globalVars.retroUnlocked)
        {
            retro.image.sprite = ret;
            rett.SetText("Retro Gamebert");
        }

        if (globalVars.raccUnlocked)
        {
            racc.image.sprite = rc;
            ract.SetText("Trash Panda");
        }
    }
    
}
