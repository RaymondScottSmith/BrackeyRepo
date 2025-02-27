using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : Problem
{
    [SerializeField] private AudioClip normalMusic;
    [SerializeField] private AudioClip spookyMusic;

    private AudioSource myAudioSource;

    private bool playingSpooky;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        myAudioSource.clip = normalMusic;
        myAudioSource.Play();
        
    }

    public void FixMusic()
    {
        myAudioSource.clip = normalMusic;
        myAudioSource.Play();
    }

    public override string InteractMessage(Grabber grabber)
    {
        if (myAudioSource.clip == spookyMusic)
        {
            return interactMessage;
        }
        else
        {
            return "";
        }
    }

    [ContextMenu("Start Spooky")]
    public override void StartEvent()
    {
        myAudioSource.clip = spookyMusic;
        myAudioSource.Play();
        playingSpooky = true;
    }

    public override void Interact(Grabber grabber)
    {
        if (playingSpooky)
        {
            FixMusic();
            playingSpooky = false;
            ProblemManager.Instance.AdvanceEvent();
        }
            
    }
}
