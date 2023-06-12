using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckpointStart : MonoBehaviour
{
    public bool hasPassHalf = false;
    public CheckpointHalfLap half;
    public GameObject LapCounter;
    public int LapsDone;
    public int MaxLaps;

    public GameObject RaceFinish;

    private void Update()
    {
        if(LapsDone > MaxLaps)
        {
            RaceFinish.SetActive(true);
        }
    }

    private void Start()
    {
        string text = "" + LapsDone + "/" + MaxLaps;
        LapCounter.GetComponent<TextMeshProUGUI>().text = text;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart))
        {
            if (hasPassHalf)
            {
                LapsDone+=1;
                LapTimeManager.MinuteCount = 0;
                LapTimeManager.SecondCount = 0;
                LapTimeManager.MiliSecondCount = 0;

                half.hasPassStart = true;
                hasPassHalf = false;
                string text = "" + LapsDone + "/" + MaxLaps;
                if(LapsDone >= MaxLaps)
                {
                    text = "" + MaxLaps + "/" + MaxLaps;
                }
                LapCounter.GetComponent<TextMeshProUGUI>().text = text;
            }
        }
    }
}
