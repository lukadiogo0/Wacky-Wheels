using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosDown : MonoBehaviour
{
    public GameObject positionDisplay;
    public bool hasPassToFront = false;
    
    private void OnTriggerExit(Collider other)
    {
        if (hasPassToFront) { 
            if (other.TryGetComponent<KartController>(out KartController kart))
            {
                NavMesh bot = transform.parent.GetComponent<NavMesh>();
                if (kart.LapsDone == bot.LapsDone) { 
                    kart.IncreasePlayerPos();
                    int playerPos = kart.GetPlayerPos();
                    positionDisplay.GetComponent<TextMeshProUGUI>().text = "" + playerPos + "/" + kart.InicialPosition;
                    hasPassToFront = false;
                }
            }
        }
    }
}
