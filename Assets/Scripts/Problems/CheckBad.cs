using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckBad : Problem
{
    private AudioSource myAudio;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    public override void StartEvent()
    {
        interactCollider.enabled = true;
    }

    public override void Interact(Grabber grabber)
    {
        myAudio.Play();
        interactCollider.enabled = false;
        grabber.DisplayMessage("safe");
        StartCoroutine(SafeMessage(grabber));
    }

    private IEnumerator SafeMessage(Grabber grabber)
    {
        yield return new WaitForSeconds(2);
        grabber.DisplayMessage("");
        ProblemManager.Instance.AdvanceEvent();
    }
}
