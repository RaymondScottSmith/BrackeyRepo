using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Grabber : Tool
{

    private Collider grabCollider;

    private bool holdingObject;

    private bool busy = false;

    

    [SerializeField] public GameObject heldPizza;
    [SerializeField] public GameObject heldMop;

    [SerializeField] public TMP_Text message;
    // Start is called before the first frame update
    void Start()
    {
        grabCollider = GetComponent<Collider>();
    }

    protected override void UseTool()
    {
        if (!busy)
        {
            base.UseTool();
            if (!holdingObject)
                StartCoroutine(GrabObject());
            else
            {
            
            }
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        
        //thisInstance.GetType().IsSubclassOf(typeof(ThatClass))
        if (other.CompareTag("PizzaGrab"))
        {
            if (!clicking)
            {
                DisplayMessage("grab pizza");
            }
            else
            {
                other.enabled = false;
                DisplayMessage("");
                heldPizza.SetActive(true);
                StartCoroutine(TurnOffDelay(other.gameObject, 5f));
            }
            
        }
        if (other.GetComponent<Problem>())
        {
            Problem problem = other.GetComponent<Problem>();
            if (clicking)
            {
                problem.Interact(this);
            }
            else
            {
                DisplayMessage(problem.InteractMessage(this));
            }
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PizzaGrab"))
        {
            DisplayMessage();
        }
        if (other.GetComponent<Problem>())
        {
            DisplayMessage();

        }
    }

    private IEnumerator TurnOffDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    public void DisplayMessage(string toSend = "")
    {
        message.text = toSend;
    }
    
    
    private IEnumerator GrabObject()
    {
        busy = true;
        grabCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        grabCollider.enabled = false;
        busy = false;
    }
}
