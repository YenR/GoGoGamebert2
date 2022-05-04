using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class gameScript : MonoBehaviour
{
    public GameObject pizza, pizzaGuy, pizzaSprite;
    public GameObject burger, burgerGuy, burgerSprite;
    public GameObject sushi, sushiGuy, sushiSprite;
    public TMP_Text deliveries;

    List<float> ratings = new List<float>{ 3f };

    public TMP_Text rating, shift_timer, pizza_timer, burger_timer, sushi_timer;
    float shift_timerf, pizza_timerf, burger_timerf, sushi_timerf;

    public float boundsxmin, boundsxmax, boundsymin, boundsymax;

    public LayerMask layermask;

    private int delis = 0;

    public static gameScript instance;

    public Animator popupAnim;
    public TMP_Text popupTxt;

    private void Start()
    {
        instance = this;

        shift_timerf = 150f;
        pizza_timerf = UnityEngine.Random.Range(30f, 59f);
        burger_timerf = UnityEngine.Random.Range(30f, 59f);
        sushi_timerf = UnityEngine.Random.Range(30f, 59f);
    }

    public Color normal, late;

    private void Update()
    {
        shift_timerf -= Time.deltaTime;
        pizza_timerf -= Time.deltaTime;
        burger_timerf -= Time.deltaTime;
        sushi_timerf -= Time.deltaTime;

        shift_timer.SetText("" + TimeSpan.FromSeconds(shift_timerf).Minutes + ":" + TimeSpan.FromSeconds(shift_timerf).Seconds.ToString("D2"));
        pizza_timer.SetText("" + ((pizza_timerf < 0f)?"-":"") + TimeSpan.FromSeconds(Mathf.Abs(pizza_timerf)).Minutes + ":" + TimeSpan.FromSeconds(Mathf.Abs(pizza_timerf)).Seconds.ToString("D2"));
        burger_timer.SetText("" + ((burger_timerf < 0f) ? "-" : "") + TimeSpan.FromSeconds(Mathf.Abs(burger_timerf)).Minutes + ":" + TimeSpan.FromSeconds(Mathf.Abs(burger_timerf)).Seconds.ToString("D2"));
        sushi_timer.SetText("" + ((sushi_timerf < 0f) ? "-" : "") + TimeSpan.FromSeconds(Mathf.Abs(sushi_timerf)).Minutes + ":" + TimeSpan.FromSeconds(Mathf.Abs(sushi_timerf)).Seconds.ToString("D2"));

        pizza_timer.color = (pizza_timerf < 0f) ? late : normal;
        burger_timer.color = (burger_timerf < 0f) ? late : normal;
        sushi_timer.color = (sushi_timerf < 0f) ? late : normal;

        if (shift_timerf <= 17f && shift_timerf > 12f && !ringtone.isPlaying)
            ringtone.PlayOneShot(ringtone.clip);

        if(shift_timerf <= 0f && Time.timeScale != 0f)
        {
            if(firstshift)
            {
                op1.PlayOneShot(op1.clip);
                firstshift = false;
            }
            else
            {
                int r = UnityEngine.Random.Range(0, 3);
                if(r==0)
                    op2.PlayOneShot(op2.clip);
                else if (r == 1)
                    op3.PlayOneShot(op3.clip);
                else
                    op4.PlayOneShot(op4.clip);
            }
            Time.timeScale = 0f;
            dm.SetActive(true);
        }
    }

    bool firstshift = true;

    public void pizzaPickup()
    {
        pizza.SetActive(false);
        pizzaGuy.SetActive(true);

        pickup.PlayOneShot(pickup.clip);
        pizzaGuy.GetComponent<pizzaGuy>().thanks.SetActive(false);
        pizzaGuy.GetComponent<pizzaGuy>().no_thanks.SetActive(false);
        pizzaGuy.GetComponent<pizzaGuy>().delivered = false;

        pizzaSprite.SetActive(true);

        do
        {
            float x = UnityEngine.Random.Range(boundsxmin, boundsxmax);
            float y = UnityEngine.Random.Range(boundsymin, boundsymax);
            Debug.Log("setting pizza guy: " + x + ", " + y);
            pizzaGuy.transform.position = new Vector3(x, y, 0);
            //Collider2D tmp = Physics2D.OverlapCircle(new Vector2(pizzaGuy.transform.position.x, pizzaGuy.transform.position.y), 2f, layermask);
            
        } while (pizzaGuy.GetComponent<pizzaGuy>().colliding || Physics2D.OverlapCircle(new Vector2(pizzaGuy.transform.position.x, pizzaGuy.transform.position.y), 2f, layermask));
    }
    
    public void burgerPickup()
    {
        burger.SetActive(false);
        burgerGuy.SetActive(true);

        pickup.PlayOneShot(pickup.clip);
        burgerGuy.GetComponent<burgerGuy>().thanks.SetActive(false);
        burgerGuy.GetComponent<burgerGuy>().no_thanks.SetActive(false);
        burgerGuy.GetComponent<burgerGuy>().delivered = false;

        burgerSprite.SetActive(true);

        do
        {
            float x = UnityEngine.Random.Range(boundsxmin, boundsxmax);
            float y = UnityEngine.Random.Range(boundsymin, boundsymax);
            Debug.Log("setting burger guy: " + x + ", " + y);
            burgerGuy.transform.position = new Vector3(x, y, 0);
            //Collider2D tmp = Physics2D.OverlapCircle(new Vector2(pizzaGuy.transform.position.x, pizzaGuy.transform.position.y), 2f, layermask);

        } while (Physics2D.OverlapCircle(new Vector2(burgerGuy.transform.position.x, burgerGuy.transform.position.y), 2f, layermask));
    }


    public void sushiPickup()
    {
        sushi.SetActive(false);
        sushiGuy.SetActive(true);

        pickup.PlayOneShot(pickup.clip);

        sushiGuy.GetComponent<sushiGuy>().thanks.SetActive(false);
        sushiGuy.GetComponent<sushiGuy>().no_thanks.SetActive(false);
        sushiGuy.GetComponent<sushiGuy>().delivered = false;

        sushiSprite.SetActive(true);

        do
        {
            float x = UnityEngine.Random.Range(boundsxmin, boundsxmax);
            float y = UnityEngine.Random.Range(boundsymin, boundsymax);
            Debug.Log("setting sushi guy: " + x + ", " + y);
            sushiGuy.transform.position = new Vector3(x, y, 0);
            //Collider2D tmp = Physics2D.OverlapCircle(new Vector2(pizzaGuy.transform.position.x, pizzaGuy.transform.position.y), 2f, layermask);

        } while (Physics2D.OverlapCircle(new Vector2(sushiGuy.transform.position.x, sushiGuy.transform.position.y), 2f, layermask));
    }

    void addRating(float newRating)
    {
        ratings.Add(newRating);
        popupTxt.SetText("New Rating: " + newRating.ToString("N1") + " Stars!");
        popupAnim.SetTrigger("show");
        rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");
    }

    public void pizzaDelivered()
    {
        if (pizzaGuy.GetComponent<pizzaGuy>().delivered)
            return;

        delivered.PlayOneShot(delivered.clip);
        delis++;
        deliveries.SetText(delis.ToString());
        //pizzaGuy.SetActive(false);
        pizzaSprite.SetActive(false);
        pizza.SetActive(true);

        if (pizza_timerf < 0)
        {
            pizzaGuy.GetComponent<pizzaGuy>().no_thanks.SetActive(true);
            addRating(1f);
            //ratings.Add(1f);
        }
        else
        {
            pizzaGuy.GetComponent<pizzaGuy>().thanks.SetActive(true);
            addRating(UnityEngine.Random.Range(1f, 5f));
            //ratings.Add(UnityEngine.Random.Range(1f, 5f));
        }

        //rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");

        pizza_timerf = UnityEngine.Random.Range(30f, 59f);

        pizzaGuy.GetComponent<pizzaGuy>().delivered = true;
    }

    public void burgerDelivered()
    {
        if (burgerGuy.GetComponent<burgerGuy>().delivered)
            return;

        delivered.PlayOneShot(delivered.clip);
        delis++;
        deliveries.SetText(delis.ToString());
        //pizzaGuy.SetActive(false);
        burgerSprite.SetActive(false);
        burger.SetActive(true);

        if (burger_timerf < 0)
        {
            burgerGuy.GetComponent<burgerGuy>().no_thanks.SetActive(true);
            addRating(1f);
            //ratings.Add(1f);
        }
        else
        {
            burgerGuy.GetComponent<burgerGuy>().thanks.SetActive(true);
            addRating(UnityEngine.Random.Range(3f, 5f));
        }

        //rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");

        burger_timerf = UnityEngine.Random.Range(30f, 59f);

        burgerGuy.GetComponent<burgerGuy>().delivered = true;
        /*
        delis++;
        deliveries.SetText(delis.ToString());
        burgerGuy.SetActive(false);
        burger.SetActive(true);

        if (burger_timerf < 0)
            ratings.Add(1f);
        else
            ratings.Add(UnityEngine.Random.Range(1f,5f));

        rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");

        burger_timerf = UnityEngine.Random.Range(30f, 59f);*/
    }

    public void sushiDelivered()
    {
        if (sushiGuy.GetComponent<sushiGuy>().delivered)
            return;

        delivered.PlayOneShot(delivered.clip);

        delis++;
        deliveries.SetText(delis.ToString());
        //pizzaGuy.SetActive(false);
        sushiSprite.SetActive(false);
        sushi.SetActive(true);

        if (sushi_timerf < 0)
        {
            sushiGuy.GetComponent<sushiGuy>().no_thanks.SetActive(true);
            addRating(1f);
        }
        else
        {
            sushiGuy.GetComponent<sushiGuy>().thanks.SetActive(true);
            addRating(UnityEngine.Random.Range(1f, 5f));
        }

        //rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");

        sushi_timerf = UnityEngine.Random.Range(30f, 59f);

        sushiGuy.GetComponent<sushiGuy>().delivered = true;

        /*
        delis++;
        deliveries.SetText(delis.ToString());
        sushiGuy.SetActive(false);
        sushi.SetActive(true);

        if (sushi_timerf < 0)
            ratings.Add(1f);
        else
            ratings.Add(UnityEngine.Random.Range(1f, 5f));

        rating.SetText("" + ratings.Average().ToString("N1") + "/5.0");

        sushi_timerf = UnityEngine.Random.Range(30f, 59f);*/
    }

    public AudioSource awesome, delivered, pickup, ringtone, op1, op2, op3, op4;
    public Animator dialog;
    public GameObject dm;
    public LevelLoader ll;

    public void resetShift()
    {
        //dialog.SetBool("isOpen", false);
        dm.SetActive(false);
        awesome.PlayOneShot(awesome.clip);
        shift_timerf = 120f;
        Time.timeScale = 1f;
    }

    public void unpause()
    {
        dm.SetActive(false);
        shift_timerf = 120f;
        Time.timeScale = 1f;
        ll.LoadNextLevel();
    }
}
