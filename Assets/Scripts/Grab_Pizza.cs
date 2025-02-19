using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Pizza : MonoBehaviour
{
    public P_ServingTable servingTable;
    public bool NeedMorePizza()
    {
        return servingTable.RemainingBoxes() == 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
