using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.UIElements;
//using Cursor = UnityEngine.UIElements.Cursor;

public class QuitButton : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        MusicManager.Instance.DestroyMe();
        SceneManager.LoadScene("Menu");
    }
}
