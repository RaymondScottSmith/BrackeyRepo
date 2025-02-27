using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : Problem
{
    protected Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    public override void StartEvent()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(Grabber grabber)
    {
        myAnimator.SetTrigger("Change");
    }
}
