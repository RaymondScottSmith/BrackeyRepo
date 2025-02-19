using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOut : Problem
{
    public GameObject pizzas;
    public GameObject pizzaMan;
    public override string InteractMessage(Grabber grabber)
    {
        if (grabber.heldPizza.activeSelf)
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
        pizzas.SetActive(false);
        pizzaMan.SetActive(true);
    }

    public override void Interact(Grabber grabber)
    {
        if (grabber.heldPizza.activeSelf)
        {
            RestockPizza();
            grabber.heldPizza.SetActive(false);
            ProblemManager.Instance.AdvanceEvent();
        }
            
    }

    public void RestockPizza()
    {
        pizzas.SetActive(true);
        
    }
}
