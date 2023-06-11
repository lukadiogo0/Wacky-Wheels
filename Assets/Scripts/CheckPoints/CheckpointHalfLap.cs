using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHalfLap : MonoBehaviour
{
    public bool hasPassStart = false;
    public CheckpointStart start;

    private void Start()
    {
        hasPassStart = true;
    }

    void OnTriggerEnter()
    {
        if (hasPassStart) {
            hasPassStart = false;
            start.hasPassHalf = true;
        }
    }
}
