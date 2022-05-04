using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessScroll : MonoBehaviour
{

    //public BoxCollider2D boxColl;
    public Rigidbody2D rb;

    public float width = 30;
    public float scrollSpeed = 2f;

    private Vector2 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-scrollSpeed, 0);
        resetPosition = new Vector2(width * 2f, 0);
    }

    public GameObject myEnemy;
    public GameObject[] enemies;

    public GameObject lb;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            transform.position = (Vector2)transform.position + resetPosition;

            if(myEnemy!=null)
                Destroy(myEnemy);

            if(enemies != null && enemies.Length > 0)
            {
                int rng = Random.Range(0, enemies.Length);
                myEnemy = Instantiate(enemies[rng], this.gameObject.transform);
            }
            else if(lb != null)
            {
                int rng = Random.Range(0, 6);
                if(rng == 0)
                {
                    myEnemy = Instantiate(lb, this.gameObject.transform);
                }
            }
        }
    }
}
