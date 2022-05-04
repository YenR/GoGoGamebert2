using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainmenuScript : MonoBehaviour
{
    public TMP_Text boxes;
    public int initial_boxes = 2;

    public LevelLoader ll;

    public AudioSource err;

    // Start is called before the first frame update
    void Start()
    {
        if(globalVars.firstTime)
        {
            globalVars.lootboxes_left = 2;
            globalVars.firstTime = false;
            StartCoroutine(showWelcomeMessage(1));
        }

        boxes.SetText(globalVars.lootboxes_left.ToString());
    }
    
    IEnumerator showWelcomeMessage(int secs)
    {
        yield return new WaitForSeconds(secs);
        errorManager.instance.updateText("Welcome, you got two (2) lootboxes!");
    }

    public void startPressed()
    {
        if(globalVars.lootboxes_left > 0)
        {
            errorManager.instance.updateText("Error: Please open all lootboxes before playing!");
            err.PlayOneShot(err.clip);
        }
        else
        {
            ll.LoadLevelByNr(3);
            //ll.LoadNextLevel();
        }
    }

    public void boxPressed()
    {
        if (globalVars.lootboxes_left <= 0)
        {
            errorManager.instance.updateText("Error: No lootboxes left!");
            err.PlayOneShot(err.clip);
        }
        else
        {
            ll.LoadLevelByNr(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
