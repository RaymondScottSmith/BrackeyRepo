using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : Problem
{

    public FridgeDoor containingFridge;
    private void Awake()
    {
        interactCollider = GetComponent<Collider>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    public override void StartEvent()
    {
        //interactCollider.enabled = true;
        containingFridge.readyForHead = true;
        if (containingFridge.doorOpen)
        {
            interactCollider.enabled = true;
        }
    }

    public override void Interact(Grabber grabber)
    {
        grabber.PlayBagBody();
        grabber.heldTrash.SetActive(true);
        grabber.DisplayMessage("trash it");
        gameObject.SetActive(false);
    }
}
