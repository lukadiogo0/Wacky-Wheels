using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointStart : MonoBehaviour
{
    public bool hasPassHalf = false;
    public CheckpointHalfLap half;

    void OnTriggerEnter()
    {
        if (hasPassHalf)
        {
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MiliSecondCount = 0;

            half.hasPassStart = true;
            hasPassHalf = false;
        }
    }
}
