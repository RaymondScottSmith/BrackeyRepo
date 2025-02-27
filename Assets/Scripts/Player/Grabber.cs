using System;
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
    public GameObject heldDrinks;
    public GameObject heldTrash;
    [SerializeField] public GameObject heldMop;

    [SerializeField] public TMP_Text message;

    public TMP_Text dialogBox;

    public GameObject dialogPanel;

    public AudioClip mopUse;
    public AudioClip drinkUse;
    public AudioClip pizzaUse;
    public AudioClip trashCanUse;
    public AudioClip bagBodyparts;
    

    private bool dialogBusy;

    private AudioSource myAudio;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }

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

    private IEnumerator DisplayDialog(string dialog)
    {
        dialogBusy = true;
        dialogBox.text = dialog;
        dialogPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogBox.text = "";
        dialogPanel.SetActive(false);
        dialogBusy = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
        //thisInstance.GetType().IsSubclassOf(typeof(ThatClass))
        /*
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
        */
        
        if (other.CompareTag("Guest"))
        {
            if (!clicking)
            {
                
            }
            else if (!dialogBusy)
            {
                StartCoroutine(DisplayDialog(other.GetComponent<Guest>().RandomDialog()));
            }
            
        }
        if (other.CompareTag("CrateGrab"))
        {
            if (!clicking)
            {
                DisplayMessage("grab drinks");
            }
            else
            {
                myAudio.PlayOneShot(drinkUse);
                other.enabled = false;
                DisplayMessage("");
                heldDrinks.SetActive(true);
                other.gameObject.SetActive(false);
            }
            
        }
        
        if (other.CompareTag("TrashCan"))
        {
            Debug.Log("Trash Can");
            if (!clicking && heldTrash.activeSelf)
            {
                DisplayMessage("hide here!");
            }
            else if (heldTrash.activeSelf)
            {
                myAudio.PlayOneShot(trashCanUse);
                other.enabled = false;
                DisplayMessage("");
                heldTrash.SetActive(false);
                ProblemManager.Instance.AdvanceEvent();
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

    public void PlayPizzaSound()
    {
        myAudio.PlayOneShot(pizzaUse);
    }

    public void PlayDrinkSound()
    {
        myAudio.PlayOneShot(drinkUse);
    }

    public void PlayBagBody()
    {
        myAudio.PlayOneShot(bagBodyparts);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PizzaGrab"))
        {
            DisplayMessage();
        }

        if (other.CompareTag("CrateGrab"))
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

    public void PlayMopUse()
    {
        myAudio.PlayOneShot(mopUse);
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
