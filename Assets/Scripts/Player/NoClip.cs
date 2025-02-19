using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClip : MonoBehaviour
{
    [SerializeField] public float distance;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask clippingLayerMask;

    [SerializeField] private AnimationCurve offsetCurve;

    private Vector3 originalLocalPosition;

    private void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    public void ChangeVariables(float newDistance, float newRadius)
    {
        distance = newDistance;
        radius = newRadius;
    }



    private void Update()
    {
        if (Physics.SphereCast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)), radius, out var hit, distance, clippingLayerMask))
        {
            transform.localPosition = originalLocalPosition - new Vector3(0.0f, 0.0f, offsetCurve.Evaluate(hit.distance/distance));
        }
        else
        {
            transform.localPosition = originalLocalPosition;
        }
    }
}
