using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScript : MonoBehaviour
{
    //public float speed = 2f;
    //public Rigidbody2D rb;

    public GameObject bulletPrefab;

    public float shootInterval = 1f;
    private void Start()
    {
        //rb.velocity = new Vector2(0, -speed);
    }

    public float shotLastTime = 0;
    public Vector3 bulletTransform = new Vector3(-2.4f, 0.65f, 0f);

    private void Update()
    {
        if (shotLastTime + shootInterval < Time.time && !PlayerControls.instance.gameOver)
        {
            shotLastTime = Time.time;
            Instantiate(bulletPrefab, this.gameObject.transform);//bulletTransform, Quaternion.identity, this.gameObject.transform);
                                                                 //bullet.transform.parent = this.gameObject.transform;
        }
    }
}
