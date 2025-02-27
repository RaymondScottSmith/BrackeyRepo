using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator introAnimator;
    public AudioSource menuAudio;

    public void StartIntro()
    {
        menuAudio.Stop();
        introAnimator.gameObject.SetActive(true);
        introAnimator.SetTrigger("StartIntro");

        StartCoroutine(DelayLoadScene("MainLevel", 17f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator DelayLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(sceneName);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
