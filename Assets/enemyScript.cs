using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    //public Animator gameOverAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag != "Player"))
            return;

        Debug.Log("collided");
        //Time.timeScale = 0;
        PlayerControls.instance.init_gameOver();
    }
}
