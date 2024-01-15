using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CheckpointHalfLap : NetworkBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart)){
            if (kart.hasPassStart) {
                kart.KartPassHalfServerRpc();
            }
        }
    }
}
