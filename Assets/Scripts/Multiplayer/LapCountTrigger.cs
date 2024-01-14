using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCountTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<KartController_Multiplayer>() != null)
        {
            WackyGameManager.Instance.KartPassFinishLine(other.gameObject);
            other.gameObject.GetComponent<KartController_Multiplayer>().KartPassFinishLine();
        }
    }
}
