using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class pedestrian : MonoBehaviour
{
    public float minTargetx, maxTargetx, minTargety, maxTargety;

    public float minSpeed, maxSpeed;

    public SpriteRenderer spriteRenderer;
    public Sprite pedL, pedR, pedU, pedD;
    public Rigidbody2D rb;
    public AIPath aiPath;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setTarget", 0.1f, 20f);
        //setTarget();
    }

    void setTarget()
    {
        if (aiPath != null)
        {
            aiPath.maxSpeed = Random.Range(minSpeed, maxSpeed);
        }
        target.localPosition = new Vector3(Random.Range(minTargetx, maxTargetx), Random.Range(minTargety, maxTargety));
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath != null)
        {
            if (Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Abs(aiPath.desiredVelocity.y))
            {
                if (aiPath.desiredVelocity.x >= 0.01f)
                {
                    spriteRenderer.sprite = pedR;
                }
                else if (aiPath.desiredVelocity.x <= -0.01f)
                {
                    spriteRenderer.sprite = pedL;
                }
            }
            else
            {
                if (aiPath.desiredVelocity.y <= -0.01f)
                {
                    spriteRenderer.sprite = pedD;
                }
                else if (aiPath.desiredVelocity.y >= 0.01f)
                {
                    spriteRenderer.sprite = pedU;
                }
            }
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                if (rb.velocity.x >= 0.01f)
                {
                    spriteRenderer.sprite = pedR;
                }
                else if (rb.velocity.x <= -0.01f)
                {
                    spriteRenderer.sprite = pedL;
                }
            }
            else
            {
                if (rb.velocity.y <= -0.01f)
                {
                    spriteRenderer.sprite = pedD;
                }
                else if (rb.velocity.y >= 0.01f)
                {
                    spriteRenderer.sprite = pedU;
                }
            }
        }
    }
}
