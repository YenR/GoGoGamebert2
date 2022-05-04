using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tooltipper : MonoBehaviour
{
    public string txt;
    public TMP_Text tooltip;

    public void setTooltip()
    {
        tooltip.SetText(txt);
    }
}
