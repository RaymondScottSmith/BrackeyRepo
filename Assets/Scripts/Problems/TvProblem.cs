using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvProblem : Problem
{

    public StaticController sController;
    private AudioSource myAudio;
    private void Awake()
    {
        interactCollider = GetComponent<Collider>();
        myAudio = GetComponent<AudioSource>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    public override void StartEvent()
    {
        interactCollider.enabled = true;
        myAudio.Play();
        sController.StartStatic();
    }

    public override void Interact(Grabber grabber)
    {
        interactCollider.enabled = false;
        sController.stop = true;
        myAudio.Stop();
        grabber.DisplayMessage("");
        ProblemManager.Instance.AdvanceEvent();
    }
}
