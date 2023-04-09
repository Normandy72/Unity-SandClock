using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] SandClock clock;

    private void Start()
    {
        clock.onRoundStart += OnRoundStart;
        clock.onRoundEnd += OnRoundEnd;
        clock.onAllRoundsCompleted += OnAllRoundsCompleted;

        clock.Begin();
    }

    private void OnRoundStart(int round)
    {
        Debug.Log("Round starts " + round);
    }

    private void OnRoundEnd(int round)
    {
        Debug.Log("Round ends " + round);
    }

    private void OnAllRoundsCompleted()
    {
        Debug.Log("All rounds completed");
    }

    private void OnDestroy()
    {
        clock.onRoundStart -= OnRoundStart;
        clock.onRoundEnd -= OnRoundEnd;
        clock.onAllRoundsCompleted -= OnAllRoundsCompleted;
    }
}
