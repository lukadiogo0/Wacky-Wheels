using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LapCountTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart))
        {
            Debug.Log(kart.hasPassHalf.Value);
            if (kart.hasPassHalf.Value == true) { 
                WackyGameManager.Instance.KartPassFinishLine(kart.gameObject);
                kart.KartPassFinishLine();
            }
        }
    }
}
