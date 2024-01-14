using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class LapCountManager : NetworkBehaviour
{
    [SerializeField] private GameObject LapCounter;
    private int lapsDone = 0;


    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        LapCounter.SetActive(true);
        LapCounter.GetComponent<TextMeshProUGUI>().text = "" + lapsDone;
    }

    public void IncreaseLap()
    {
        if (!IsOwner) return;
        lapsDone++;
    }
}
