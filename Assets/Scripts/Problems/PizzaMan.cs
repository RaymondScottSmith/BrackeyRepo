using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMan : Problem
{
    public Animator doorAnimator;
    public GameObject heldPizza;

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
        throw new System.NotImplementedException();
    }

    public override void Interact(Grabber grabber)
    {
        interactCollider.enabled = false;
        grabber.heldPizza.SetActive(true);
        grabber.DisplayMessage("");

        grabber.PlayPizzaSound();
        StartCoroutine(RemovePizzaMan());

    }

    private IEnumerator RemovePizzaMan()
    {
        heldPizza.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        doorAnimator.SetTrigger("Change");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
