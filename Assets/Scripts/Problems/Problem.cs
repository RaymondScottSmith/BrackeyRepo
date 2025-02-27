using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Problem : MonoBehaviour
{
    [SerializeField]
    protected string interactMessage;

    [TextArea]
    public string instructions;

    public Collider interactCollider;

    public abstract string InteractMessage(Grabber grabber);
    public abstract void StartEvent();

    public abstract void Interact(Grabber grabber);

}
