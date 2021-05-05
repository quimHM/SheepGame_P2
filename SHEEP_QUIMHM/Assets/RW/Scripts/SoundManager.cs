﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // 1

    public AudioClip shootClip; // 2
    public AudioClip sheepHitClip; // 3
    public AudioClip sheepDroppedClip; // 4
    public AudioClip hurtClip; // 4

    private Vector3 cameraPosition; // 5

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; // 1
        cameraPosition = Camera.main.transform.position; // 2
    }
    
    private void PlaySound(AudioClip clip) // 1
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition); // 2
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlayHurtClip()
    {
        PlaySound(hurtClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}