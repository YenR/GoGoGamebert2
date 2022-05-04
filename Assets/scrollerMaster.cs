using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollerMaster : MonoBehaviour
{
    public static scrollerMaster instance;

    public endlessScroll[] scrollers;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scrollSpeed = startScrollSpeed;
        updateScrollSpeed(scrollSpeed);
        uTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControls.instance.gameOver)
        {
            scrollSpeed = 0f;
            updateScrollSpeed(0f);
            return;

        }

        if(uTime + updateInterval < Time.time)
        {
            scrollSpeed += updateValue;
            uTime = Time.time;
            updateScrollSpeed(scrollSpeed);
        }
    }

    public void reduceSpeed()
    {
        scrollSpeed -= deductSpeed;
        updateScrollSpeed(scrollSpeed);
    }

    public void addSpeed()
    {
        scrollSpeed += addedSpeed;
        updateScrollSpeed(scrollSpeed);
    }

    public float updateInterval = 1f, updateValue = 0.1f;

    public float startScrollSpeed = 6f, minScrollSpeed = 3f, maxScrollSpeed = 24f;
    public float scrollSpeed, uTime;

    public float addedSpeed = 2f, deductSpeed = 2f;

    public void updateScrollSpeed(float newSpeed)
    {
        if (PlayerControls.instance != null && PlayerControls.instance.gameOver)
            newSpeed = 0f;
        else
            scrollSpeed = newSpeed = Mathf.Clamp(newSpeed, minScrollSpeed, maxScrollSpeed);

        foreach( endlessScroll es in scrollers )
        {
            es.scrollSpeed = newSpeed;
            es.rb.velocity = new Vector2(-newSpeed, 0);
        }
    }

}
