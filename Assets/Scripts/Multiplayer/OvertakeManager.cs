using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart))
        {
            int overtakerPos = WackyGameManager.Instance.GetKartPosition(kart.gameObject) + 1;
            int overtakenPos = WackyGameManager.Instance.GetKartPosition(gameObject.transform.parent.gameObject) + 1;
            Debug.Log("overtakerPos " + overtakerPos);
            Debug.Log("overtakenPos " + overtakenPos);
            Debug.Log("kart" + kart.gameObject);
            int overtakerLap = kart.GetKartLap();
            int overtakenLap = gameObject.GetComponent<KartController_Multiplayer>().GetKartLap();

            Debug.Log("overtakerLap " + overtakerLap);
            Debug.Log("overtakenLap " + overtakenLap);
            if (overtakerPos < overtakenPos && overtakenLap == overtakerLap)
            {
                WackyGameManager.Instance.UpdateKartListPos(kart.gameObject, gameObject);
            }
        }
    }
}
