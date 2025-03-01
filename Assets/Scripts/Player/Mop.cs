using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Tool
{
    private bool busy;
    private bool collBusy;

    public float delay = 1f;

    public Animator mopAnimator;

    private Grabber playerGrabber;

    private void OnEnable()
    {
        busy = false;
        collBusy = false;
    }

    private void Awake()
    {
        playerGrabber = mopAnimator.GetComponentInChildren<Grabber>();
    }

    protected override void Update()
    {
        if (!busy && Input.GetMouseButtonDown(0))
        {
            busy = true;
            playerGrabber.PlayMopUse();
            mopAnimator.SetTrigger("Use");
            StartCoroutine(DelayMop());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!collBusy && other.CompareTag("Mopable"))
        {
            collBusy = true;
            other.GetComponent<MopMess>().ScrubMess(this);
            
        }
    }

    private IEnumerator DelayMop()
    {
        yield return new WaitForSeconds(delay);
        busy = false;
        collBusy = false;
    }
}
