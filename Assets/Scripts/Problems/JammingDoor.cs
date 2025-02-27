using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammingDoor : Problem
{
    public bool jammed;
    public GameObject stuckGuest;
    
    private Animator myAnimator;
    private AudioSource myAudio;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        if (jammed)
        {
            return interactMessage;
        }
        else
            return "";
    }

    public override void StartEvent()
    {
        jammed = true;
        stuckGuest.SetActive(true);
    }

    public override void Interact(Grabber grabber)
    {
        if (jammed)
        {
            myAudio.Play();
            jammed = false;
            myAnimator.SetTrigger("Change");
            grabber.DisplayMessage("");
            ProblemManager.Instance.AdvanceEvent();
        }
        
    }
}
