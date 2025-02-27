using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProblemManager : MonoBehaviour
{

    public static ProblemManager Instance;
    
    public List<Problem> problems;

    //Upon each problem completing the corresponding time is waited before the next problem starts
    public List<float> timeBeforeProblem;

    public int currentProblem = 0;

    public TMP_Text instructions;

    public Image instructionBox;

    private void Awake()
    {
        if (ProblemManager.Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(WaitTillProblem(currentProblem));
    }

    public void AdvanceEvent()
    {
        currentProblem++;
        if (currentProblem < problems.Count)
            StartCoroutine(WaitTillProblem(currentProblem));
    }

    private IEnumerator WaitTillProblem(int index)
    {
        instructions.text = "";
        instructionBox.enabled = false;
        yield return new WaitForSeconds(timeBeforeProblem[index]);
        problems[index].gameObject.SetActive(true);
        instructions.text = problems[index].instructions;
        problems[index].StartEvent();
        instructionBox.enabled = true;
    }
}
