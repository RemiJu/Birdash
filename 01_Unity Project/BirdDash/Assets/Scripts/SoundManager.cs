using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sources")]
    public AudioSource audioSource;
    public AudioClip fallOver;
    public AudioClip gameOver;
    public AudioClip successDelivery;
    public AudioClip newDelivery;
    public AudioClip stolenDelivery;


    public void FallingSound() 
    {
        audioSource.PlayOneShot(fallOver);
    }

    public void Delivered()     
    {
        audioSource.PlayOneShot(successDelivery);
    }

    public void NewDelivery()
    {
        audioSource.PlayOneShot(newDelivery);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }
    public void Stolen()
    {
        audioSource.PlayOneShot(stolenDelivery);
    }
}

