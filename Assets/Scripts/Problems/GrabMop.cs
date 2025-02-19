using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMop : Problem
{
    private void Awake()
    {
        interactCollider = GetComponent<Collider>();
        interactCollider.enabled = false;
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }
    
    public override void StartEvent()
    {
        gameObject.SetActive(true);
        interactCollider.enabled = true;
    }
    
    public override void Interact(Grabber grabber)
    {
        grabber.heldMop.SetActive(true);
        grabber.DisplayMessage("");
        gameObject.SetActive(false);

    }
}
