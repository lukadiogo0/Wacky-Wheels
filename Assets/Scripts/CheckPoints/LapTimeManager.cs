using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapTimeManager : MonoBehaviour
{

    public static int MinuteCount = 0;
    public static int SecondCount = 0;
    public static float MiliSecondCount = 0;
    public static string MiliSecondDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MiliSecondBox;

    void Update()
    {
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
