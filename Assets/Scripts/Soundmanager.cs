using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    public static SoundManager instance;

    public AudioClip throw1;
    public AudioClip throw2;
    public AudioClip throw3;
    public AudioClip click1;
    public AudioClip defeat;
    public AudioClip right_patient;
    public AudioClip start_game;
    public AudioClip victory;
    public AudioClip wrong_patient;
    public AudioClip loadingscreen1;

    private void Awake()
    {
        instance = this;
    }

    public void Play_Throw1()
    {
        audioSource.clip = throw1;
        audioSource.Play();
    }

    public void Play_Throw2()
    {
        audioSource.clip = throw2;
        audioSource.Play();
    }

    public void Play_Throw3()
    {
        audioSource.clip = throw3;
        audioSource.Play();
    }

    public void Play_Click()
    {
        audioSource.clip = click1;
        audioSource.Play();
    }

    public void Play_DefeatSound()
    {
        audioSource.clip = defeat;
        audioSource.Play();
    }

    public void Play_Right_Patient()
    {
        audioSource.clip = right_patient;
        audioSource.Play();
    }

    public void Play_Start_Game()
    {
        audioSource.clip = start_game;
        audioSource.Play();
    }

    public void Play_victory()
    {
        audioSource.clip = victory;
        audioSource.Play();
    }

    public void Play_Wrong_Patient()
    {
        audioSource.clip = wrong_patient;
        audioSource.Play();
    }

    public void Play_LoadingScreen()
    {
        audioSource.clip = loadingscreen1;
        audioSource.Play();
    }
}