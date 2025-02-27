using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    public Light myLight;
    public float maxWait = 1;
    public float maxFlicker = 0.2f;

    float timer;
    float interval;

    private bool flickering;
    private AudioSource myAudio;

    private void Awake()
    {
        myLight = GetComponent<Light>();
        myAudio = GetComponent<AudioSource>();
    }

    [ContextMenu("Start Flickering")]
    public void StartFlicker()
    {
        flickering = true;
        myAudio.Play();
    }

    [ContextMenu("Stop Flickering")]
    public void StopFlicker()
    {
        flickering = false;
        myLight.enabled = true;
        myAudio.Stop();
    }
    void Update()
    {
        if (flickering)
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                ToggleLight();
            }
        }
        
    }

    void ToggleLight()
    {
        myLight.enabled = !myLight.enabled;
        if (myLight.enabled)
        {
            interval = Random.Range(0, maxWait);
        }
        else 
        {
            interval = Random.Range(0, maxFlicker);
        }
    
        timer = 0;
    }
    
}
