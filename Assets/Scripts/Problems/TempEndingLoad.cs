using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempEndingLoad : Problem
{
    public override string InteractMessage(Grabber grabber)
    {
        throw new System.NotImplementedException();
    }

    public override void StartEvent()
    {
        Invoke(nameof(LoadEndingScene), 5);
    }

    private void LoadEndingScene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public override void Interact(Grabber grabber)
    {
        throw new System.NotImplementedException();
    }
}
