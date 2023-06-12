using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHalfLap : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart)){
            if (kart.hasPassStart) {
                kart.hasPassStart = false;
                kart.hasPassHalf = true;
            }
        }
        if (other.TryGetComponent<NavMesh>(out NavMesh bot))
        {
            if (bot.hasPassStart)
            {
                bot.hasPassStart = false;
                bot.hasPassHalf = true;
            }
        }
    }
}
