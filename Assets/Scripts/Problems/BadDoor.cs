using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDoor : Problem
{
    public GameObject curiousGuest;
    public Animator guestAnimator;

    private void Awake()
    {
        
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    
    public override void StartEvent()
    {
        curiousGuest.transform.localRotation = new Quaternion(0, 0, 0, 0);
        guestAnimator.SetTrigger("Again");
    }

    public override void Interact(Grabber grabber)
    {
       grabber.DisplayMessage("Insert distraction message here later.");
       curiousGuest.transform.localRotation = new Quaternion(0, 180, 0, 0);
       guestAnimator.SetTrigger("Again");
       ProblemManager.Instance.AdvanceEvent();
    }
}
