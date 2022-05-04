using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public AudioSource exp;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    private void Update()
    {
        if (this.gameObject.transform.position.x < (PlayerControls.instance.gameObject.transform.position.x - 10f))
        {
            Debug.Log("bullet destroy");
            Destroy(this.gameObject);
        }
    }

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("explode");
        exp.PlayOneShot(exp.clip);

        if ((collision.gameObject.tag == "Player"))
        {
            Debug.Log("bullet hit");
            //Time.timeScale = 0;
            PlayerControls.instance.init_gameOver();
        }

        StartCoroutine(killMe(1));
    }

    IEnumerator killMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(this.gameObject);
    }
}