using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public TMP_Text dialogText;
    public GameObject dialogPanel;
    [TextArea]
    public string cutsceneDialog;

    public Animator displayAnimator;
    public Animator cutsceneAnimator;

    public AudioClip firstLock;
    public AudioClip secondLock;

    private AudioSource myAudio;


    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        displayAnimator.SetTrigger("Start");
        Invoke("StartCutscene", 12f);
    }

    private void StartCutscene()
    {
        cutsceneAnimator.SetTrigger("Start");
        MusicManager.Instance.StartMusic();
    }

    public void DisplayDialog(string dialog)
    {
        dialogPanel.SetActive(true);
        dialogText.text = dialog;
    }

    public void PlayFirstLock()
    {
        myAudio.PlayOneShot(firstLock);
    }

    public void PlaySecondLock()
    {
        myAudio.PlayOneShot(secondLock);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
