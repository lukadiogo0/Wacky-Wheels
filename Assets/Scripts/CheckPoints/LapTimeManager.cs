using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class LapTimeManager : NetworkBehaviour
{

    private static int MinuteCount = 0;
    private static int SecondCount = 0;
    private static float MiliSecondCount = 0;
    private static string MiliSecondDisplay;
    private bool canUpdate = false;

    [SerializeField] private GameObject MinuteBox;
    [SerializeField] private GameObject SecondBox;
    [SerializeField] private GameObject MiliSecondBox;

    void Update()
    {
        if (!IsOwner)  return;
            if (canUpdate) { 
            MinuteBox.SetActive(true);
            SecondBox.SetActive(true);
            MiliSecondBox.SetActive(true);

            MiliSecondCount += Time.deltaTime * 10;
        
            if (MiliSecondCount >= 10)
            {
                MiliSecondCount -= 10;
                SecondCount += 1;
            }

            MiliSecondDisplay = Mathf.Floor(MiliSecondCount).ToString("F0");
            MiliSecondBox.GetComponent<TextMeshProUGUI>().text = "" + MiliSecondDisplay;

            if (SecondCount <= 9)
            {
                SecondBox.GetComponent<TextMeshProUGUI>().text = "0" + SecondCount + ".";
            }
            else
            {
                SecondBox.GetComponent<TextMeshProUGUI>().text = "" + SecondCount + ".";
            }

            if (SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount += 1;
            }

            if (MinuteCount <= 9)
            {
                MinuteBox.GetComponent<TextMeshProUGUI>().text = "0" + MinuteCount + ":";
            }
            else
            {
                MinuteBox.GetComponent<TextMeshProUGUI>().text = "" + MinuteCount + ":";
            }
        }
    }

    public void SetCanUpdate(bool canUpdate)
    {
        this.canUpdate = canUpdate;
    }

    public void ResetTime()
    {
        if (!IsOwner) return;
        MinuteCount = 0;
        SecondCount = 0;
        MiliSecondCount = 0;
    }
}
