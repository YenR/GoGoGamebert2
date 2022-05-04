using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizzaGuy : MonoBehaviour
{
    public GameObject thanks, no_thanks;
    public bool delivered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameScript.instance.pizzaDelivered();
        }
    }

    public bool colliding = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            colliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            colliding = false;
        }
    }
}
