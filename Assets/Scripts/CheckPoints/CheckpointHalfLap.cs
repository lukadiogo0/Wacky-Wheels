using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHalfLap : MonoBehaviour
{
    public bool hasPassStart = true;
    public CheckpointStart start;

    private void Start()
    {
        hasPassStart = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart)){ 
           if (hasPassStart) {
                hasPassStart = false;
                start.hasPassHalf = true;
            }
        }
    }
}
