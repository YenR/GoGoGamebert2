using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameScript.instance.sushiPickup();
        }
    }
}
