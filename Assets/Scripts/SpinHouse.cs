using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHouse : MonoBehaviour
{
    public float spinSpeed = 1f;

    private void Update()
    {
        Vector3 currentRot = transform.eulerAngles;
        transform.Rotate(new Vector3(0, spinSpeed*Time.deltaTime, 0));
    }
}
