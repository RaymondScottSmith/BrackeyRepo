using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriousGuest : Problem
{
    public Animator guestAnimator;

    private void Awake()
    {
        guestAnimator = GetComponentInChildren<Animator>();
        interactCollider = GetComponent<Collider>();
        guestAnimator.SetFloat("DrinkSpeed", Random.Range(0.8f, 1.2f));
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    [ContextMenu("Start Event")]
    public override void StartEvent()
    {
        interactCollider.enabled = true;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        guestAnimator.SetTrigger("Again");
    }

    public override void Interact(Grabber grabber)
    {
        grabber.DisplayMessage("");
        transform.localRotation = new Quaternion(0, 180, 0, 0);
        guestAnimator.SetTrigger("Again");
        interactCollider.enabled = false;
        ProblemManager.Instance.AdvanceEvent();
    }
}
