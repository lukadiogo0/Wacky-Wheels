using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LapCountTrigger : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart))
        {
            if (kart.hasPassHalf) { 
                WackyGameManager.Instance.KartPassFinishLine(other.gameObject);
                kart.KartPassFinishLineServerRpc();
            }
        }
    }
}
