using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    protected bool selected;
    protected bool clicking = false;
    
    protected virtual void UseTool()
    {
        
    }

    protected virtual void StopTool()
    {
        
    }
    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(gameObject.name + " Activated!");
            clicking = true;

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(gameObject.name + " De-Activated!");
            clicking = false;
        }
    }
}
