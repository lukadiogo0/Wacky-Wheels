using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int overtakerPos = WackyGameManager.Instance.GetKartPosition(other.gameObject);
        int overtakenPos = WackyGameManager.Instance.GetKartPosition(gameObject.transform.parent.gameObject);

        int overtakerLap = other.gameObject.GetComponent<KartController_Multiplayer>().GetKartLap();
        int overtakenLap = gameObject.transform.parent.gameObject.GetComponent<KartController_Multiplayer>().GetKartLap();

        if (overtakerPos < overtakenPos && overtakenLap == overtakerLap)
        {

        }
    }
}
