using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHalfLap : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart)){
            if (kart.hasPassStart.Value == true) {
                kart.hasPassStart.Value = false;
                kart.hasPassHalf.Value = true;
            }
        }
    }
}
