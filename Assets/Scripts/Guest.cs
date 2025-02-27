using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{

    public GuestAnim currentAnimation;
    private Animator myAnimator;
    public List<string> dialogues;

    public List<AudioClip> grunts;
    private AudioSource myAudio;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(DelayAnimationStart());

    }
    
    private IEnumerator DelayAnimationStart()
    {
        yield return new WaitForSeconds(Random.Range(0f,1f));
        myAnimator = GetComponentInChildren<Animator>();
        switch (currentAnimation)
        {
            case GuestAnim.Dancing:
                myAnimator.SetFloat("DrinkSpeed", Random.Range(0.8f, 1.2f));
                myAnimator.SetInteger("animation", 1);
                break;
            case GuestAnim.Drinking:
                myAnimator.SetFloat("DrinkSpeed", Random.Range(0.8f, 1.2f));
                myAnimator.SetInteger("animation", 2);
                break;
            case GuestAnim.Sitting:
                myAnimator.SetInteger("animation", 3);
                break;
        }
    }

    public string RandomDialog()
    {
        myAudio.PlayOneShot(grunts[Random.Range(0, grunts.Count)]);
        return dialogues[Random.Range(0, dialogues.Count)];
    }
    
    
    
}



public enum GuestAnim
{
    Dancing,
    Drinking,
    Sitting
}
