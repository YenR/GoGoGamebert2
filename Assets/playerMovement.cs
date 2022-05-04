using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float baseSpeed = 5f, maxSpeed = 10f;//, speed = 5f;
    public float accel = 1f;
    public float naturalSlow = 0.9f, breakingSlow = 0.6f;

    public float speedHorizontal = 0f, speedVertical = 0f;

    public Rigidbody2D rb;
    public Vector2 movement;

    public Joystick joystick;

    public Animator animator;

    public static bool canMove = true;
    //public bool startLookingUp = false;

    public float stopRunningThreshold = 70f;
    public float runSpeed = 10f;

    public LevelLoader ll;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Escape key was released");
            ll.LoadLevelByNr(0);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(joystick != null)
        {
            if (Mathf.Abs(joystick.Horizontal) >= 0.2f)
            {
                movement.x = joystick.Horizontal;
            }

            if (Mathf.Abs(joystick.Vertical) >= 0.2f)
            {
                movement.y = joystick.Vertical;
            }
        }

        if (movement != Vector2.zero)
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }

        //animator.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //Debug.Log(movement.x + ", " + movement.y);
        /*
        if (movement.x == 0f && movement.y == 0f) // slow down
        {
            speedHorizontal = (speedHorizontal > 0)?(speedHorizontal - speedHorizontal * naturalSlow * Time.fixedDeltaTime): (speedHorizontal + speedHorizontal * naturalSlow * Time.fixedDeltaTime);
            speedVertical = (speedVertical > 0) ? (speedVertical - speedVertical * naturalSlow * Time.fixedDeltaTime) : (speedVertical + speedVertical * naturalSlow * Time.fixedDeltaTime);

            if (Mathf.Abs(speedHorizontal) <= 0.05f)
                speedHorizontal = 0f;

            if (Mathf.Abs(speedVertical) <= 0.05f)
                speedVertical = 0f;
        }

        if (speedHorizontal != 0f)   // keep moving 
        {
            if (movement.x == 0f && movement.y != 0f) // change from horizontal to vertical movement
            {

            }
            else if(movement.x != 0f)
            {
                if (movement.x > 0f && speedHorizontal > 0f)
                    speedHorizontal += accel * Time.fixedDeltaTime;
            }

        }
        else if (speedVertical != 0f)
        {

        }
        else    // start moving
        {
            if (movement.x != 0f)
            {
                speedHorizontal = ((movement.x > 0f) ? 1 : -1) * baseSpeed;
            }
            else if (movement.y != 0f)
            {
                speedVertical = ((movement.y > 0f) ? 1 : -1) * baseSpeed;
            }
        }*/

        movement.Normalize();
        //Debug.Log(rb.position + movement * speed * Time.fixedDeltaTime);
        /*if(speedHorizontal != 0f)
        {
            rb.MovePosition(rb.position + new Vector2(1,0) * speedHorizontal * Time.fixedDeltaTime);
        }
        else if(speedVertical != 0f)
        {
            rb.MovePosition(rb.position + new Vector2(0,1) * speedVertical * Time.fixedDeltaTime);
        }*/

        rb.AddForce(movement, ForceMode2D.Impulse);

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }
    
}
