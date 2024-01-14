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



    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        PosCounter.SetActive(true);
        PosCounter.GetComponent<TextMeshProUGUI>().text = "0 / " + WackyGameManager.Instance.totalPlayers;
    }


}
