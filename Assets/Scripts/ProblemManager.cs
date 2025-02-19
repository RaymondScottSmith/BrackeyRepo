using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemManager : MonoBehaviour
{

    public static ProblemManager Instance;
    
    public List<Problem> problems;

    //Upon each problem completing the corresponding time is waited before the next problem starts
    public List<float> timeBeforeProblem;

    public int currentProblem = 0;

    public List<GameObject> mopMesses;

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
        yield return new WaitForSeconds(timeBeforeProblem[index]);
        problems[index].gameObject.SetActive(true);
        problems[index].StartEvent();
    }
}
