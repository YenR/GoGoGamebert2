using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class carController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite carL, carR, carU, carD;
    public Rigidbody2D rb;

    public Animator caranim;

    public float carSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        if (crashCooldown + ccd > Time.time)
            return;

        //spriteRenderer = this.GetComponent<SpriteRenderer>();

        if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            if (rb.velocity.x >= 0.01f)
            {
                //Debug.Log("r");
                spriteRenderer.sprite = carR;
            }
            else if (rb.velocity.x <= -0.01f)
            {
               // Debug.Log("l");
                spriteRenderer.sprite = carL;
            }
        }
        else
        {
            if (rb.velocity.y <= -0.01f)
            {
                spriteRenderer.sprite = carD;
            }
            else if (rb.velocity.y >= 0.01f)
            {
                spriteRenderer.sprite = carU;
            }
        }

        // genius car AI
        if(rb.velocity.magnitude <= 0.1f || Random.Range(0f,10f) > 9f)
        {
            if(Random.Range(0f, 10f) > 9.8f)
            {
                if(Mathf.Abs(rb.velocity.x) > 0.1f)
                    rb.AddForce(((rb.velocity.x > 0.1f) ? 1f : -1f) * new Vector2(0f, Random.Range(1f, 5f) * carSpeed));
                else
                    rb.AddForce(((rb.velocity.x > 0.1f) ? 1f : -1f) * new Vector2(Random.Range(1f, 5f) * carSpeed, 0f));

            }
            else if (Mathf.Abs(rb.velocity.x)>0.1f)
                rb.AddForce(((rb.velocity.x > 0.1f)?1f:-1f)* new Vector2(Random.Range(1f, 5f) * carSpeed, 0f));
            else if (Mathf.Abs(rb.velocity.y) > 0.1f)
                rb.AddForce(((rb.velocity.y > 0.1f) ? 1f : -1f) * new Vector2(0f, Random.Range(1f, 5f) * carSpeed));
            else if(Random.Range(0f, 1f) > 0.5f)
                rb.AddForce(((Random.Range(0f, 1f) > 0.5f)?1f:-1f) * new Vector2(Random.Range(1f, 5f) * carSpeed, 0f));
            else
                rb.AddForce(((Random.Range(0f, 1f) > 0.5f) ? 1f : -1f) * new Vector2(0f, Random.Range(1f, 5f) * carSpeed));

        }

        
        if (rb.velocity != Vector2.zero)
        {
            caranim.SetFloat("horizontal", rb.velocity.x);
            caranim.SetFloat("vertical", rb.velocity.y);
        }
    }

    public float ccd = 3f;
    float crashCooldown = -3f;

    public AudioSource crash;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pedestrian" && crashCooldown + ccd < Time.time)
        {
            if (collision.gameObject.GetComponent<pedestrian>() == null)
                return;

            caranim.SetTrigger("explosion");
            rb.velocity = Vector2.zero;
            crashCooldown = Time.time;
            crash.PlayOneShot(crash.clip);
        }
    }
}
