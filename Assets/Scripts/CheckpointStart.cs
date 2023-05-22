using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointStart : MonoBehaviour
{
    public GameObject CheckpointStartTrigger;
    public GameObject CheckpointHalfLapTrigger;

    void OnTriggerEnter()
    {
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliSecondCount = 0;

        CheckpointHalfLapTrigger.SetActive(true);
        CheckpointStartTrigger.SetActive(false);
    }
}
