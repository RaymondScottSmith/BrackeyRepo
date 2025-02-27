using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDoor : BasicDoor
{
    public Collider DrinksCollider;
    public bool doorOpen;
    public bool waiting;

    public bool readyForHead;

    public Collider headCollider;

    private IEnumerator TouchDelay()
    {
        waiting = true;
        yield return new WaitForSeconds(1f);
        
        waiting = false;
        if (doorOpen && readyForHead)
        {
            headCollider.enabled = true;
        }
    }
    public override void Interact(Grabber grabber)
    {
        if (!waiting)
        {
            StartCoroutine(TouchDelay());
            doorOpen = !doorOpen;
            myAnimator.SetTrigger("Change");
            if (doorOpen)
            {
                DrinksCollider.enabled = true;
                
            }
            else
            {
                DrinksCollider.enabled = false;
                headCollider.enabled = false;
            }
        }
        
    }
}
