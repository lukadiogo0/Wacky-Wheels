using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHalfLap : MonoBehaviour
{
    public GameObject CheckpointStartTrigger;
    public GameObject CheckpointHalfLapTrigger;

    void OnTriggerEnter()
    {
        CheckpointStartTrigger.SetActive(true);
        CheckpointHalfLapTrigger.SetActive(false);
    }
}
