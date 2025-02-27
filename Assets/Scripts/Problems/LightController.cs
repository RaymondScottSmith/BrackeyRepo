using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Problem
{
    [SerializeField] private List<FlickerLights> lights;
    private AudioSource myAudio;
    private void Awake()
    {
        interactCollider = GetComponent<Collider>();
        interactCollider.enabled = false;
        myAudio = GetComponent<AudioSource>();
    }
    public override string InteractMessage(Grabber grabber)
    {
        return interactMessage;
    }

    public override void StartEvent()
    {
        interactCollider.enabled = true;
        foreach (FlickerLights light in lights)
        {
            light.StartFlicker();
        }
    }

    public override void Interact(Grabber grabber)
    {
        grabber.DisplayMessage("");
        StartCoroutine(NoiseAndDelay());
        
    }

    private IEnumerator NoiseAndDelay()
    {
        
        interactCollider.enabled = false;
        myAudio.Play();
        yield return new WaitForSeconds(1);
        foreach (FlickerLights light in lights)
        {
            light.StopFlicker();
           
        }
        ProblemManager.Instance.AdvanceEvent();
    }
}
