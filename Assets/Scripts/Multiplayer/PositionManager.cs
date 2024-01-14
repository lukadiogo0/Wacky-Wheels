using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class PositionManager : NetworkBehaviour
{
    [SerializeField] private GameObject PosCounter;
    private int position = 0;

    void Update()
    {
        if (!IsOwner) return;
        PosCounter.SetActive(true);
        position = WackyGameManager.Instance.GetKartPosition(gameObject.transform.parent.gameObject) + 1;
        
        if (position > 0) { 
            PosCounter.GetComponent<TextMeshProUGUI>().text = "" + position + "/" + WackyGameManager.Instance.GetTotalKarts();
        }
    }


}
