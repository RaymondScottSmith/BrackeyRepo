using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinksOut : Problem
{
    public GameObject drinksOnTable;
    public Collider fridgeOpenCollider;
    public override string InteractMessage(Grabber grabber)
    {
        if (grabber.heldDrinks.activeSelf)
        {
            return interactMessage;
        }
        else
        {
            return "";
        }
    }

    public override void StartEvent()
    {
        fridgeOpenCollider.enabled = true;
        drinksOnTable.SetActive(false);
    }

    public override void Interact(Grabber grabber)
    {
        if (grabber.heldDrinks.activeSelf)
        {
            grabber.PlayDrinkSound();
            RestockDrinks();
            grabber.heldDrinks.SetActive(false);
            ProblemManager.Instance.AdvanceEvent();
        }
    }

    private void RestockDrinks()
    {
        drinksOnTable.SetActive(true);
    }
}
