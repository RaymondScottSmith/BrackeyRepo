using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class P_ServingTable : MonoBehaviour
{
    public List<GameObject> pizzaBoxes;

    public bool countingDown;

    public Vector2 delayRange = new Vector2(5,30);
    private float timer = 0;
    [SerializeField] private int remainingBoxes = 4;

    private void Start()
    {
        remainingBoxes = pizzaBoxes.Count;
        timer = Random.Range(delayRange.x, delayRange.y);
    }
    private void Update()
    {
        if (countingDown)
        {
            if (timer <= 0)
            {
                pizzaBoxes[remainingBoxes-1].SetActive(false);
                timer = Random.Range(delayRange.x, delayRange.y);
                remainingBoxes--;
            }

            if (remainingBoxes == 0)
                countingDown = false;

            timer -= Time.fixedDeltaTime;
        }
    }
    
    public void RestockPizza()
    {
        foreach (GameObject box in pizzaBoxes)
        {
            box.SetActive(true);
        }

        remainingBoxes = pizzaBoxes.Count;
        countingDown = true;
    }

    public int RemainingBoxes()
    {
        return remainingBoxes;
    }
}
