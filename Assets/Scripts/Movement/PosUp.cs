using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosUp : MonoBehaviour
{
    public GameObject positionDisplay;
    public PosDown PosDownTrigger;

    private void OnTriggerExit(Collider other)
    {
        if (!PosDownTrigger.hasPassToFront)
        {
            if (other.TryGetComponent<KartController>(out KartController kart))
            {
                NavMesh bot = transform.parent.GetComponent<NavMesh>();
                if (kart.LapsDone == bot.LapsDone)
                {
                    kart.DecreasePlayerPos();
                    int playerPos = kart.GetPlayerPos();
                    positionDisplay.GetComponent<TextMeshProUGUI>().text = "" + playerPos + "/" + kart.InicialPosition;
                    PosDownTrigger.hasPassToFront = true;
                }
            }
        }
    }
}
