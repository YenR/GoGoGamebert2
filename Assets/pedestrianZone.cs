using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianZone : MonoBehaviour
{
    public float maxSpeed = 30f, reducedSpeed = 18f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("entering pedestrian zone");
            collision.gameObject.GetComponent<playerMovement>().maxSpeed = reducedSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("leaving pedestrian zone");
            collision.gameObject.GetComponent<playerMovement>().maxSpeed = maxSpeed;
        }
    }
}
