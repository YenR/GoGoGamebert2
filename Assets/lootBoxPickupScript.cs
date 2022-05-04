using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootBoxPickupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            PlayerControls.instance.lootBoxesEarned++;
            PlayerControls.instance.pickup.PlayOneShot(PlayerControls.instance.pickup.clip);
            Destroy(this.gameObject);
        }
    }
}
