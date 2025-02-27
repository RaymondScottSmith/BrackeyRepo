using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Specifically for music at the end of the game

    private AudioSource myAudio;
    public static MusicManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        myAudio = GetComponent<AudioSource>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyMe();
        }
    }
    
    public void StartMusic()
    {
        myAudio.Play();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    
}
