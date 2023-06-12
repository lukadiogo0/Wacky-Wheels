using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckpointStart : MonoBehaviour
{
    public GameObject LapCounter;
    public KartController kart;
    public int MaxLaps;

    public GameObject RaceFinish;

    private void Update()
    {
        if(kart.LapsDone + 1 > MaxLaps)
        {
            RaceFinish.SetActive(true);
        }
    }

    private void Start()
    {
        string text = "" + 1 + "/" + MaxLaps;
        LapCounter.GetComponent<TextMeshProUGUI>().text = text;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart))
        {
            if (kart.hasPassHalf)
            {
                kart.IncreaseLap();
                LapTimeManager.MinuteCount = 0;
                LapTimeManager.SecondCount = 0;
                LapTimeManager.MiliSecondCount = 0;

                kart.hasPassStart = true;
                kart.hasPassHalf = false;
                string text = "" + kart.LapsDone + "/" + MaxLaps;
                if(kart.LapsDone + 1 >= MaxLaps)
                {
                    text = "" + MaxLaps + "/" + MaxLaps;
                }
                LapCounter.GetComponent<TextMeshProUGUI>().text = text;
            }
        }

        if (other.TryGetComponent<NavMesh>(out NavMesh bot))
        {
            if (bot.hasPassHalf) { 
                bot.IncreaseLap();
                bot.hasPassStart = true;
                bot.hasPassHalf = false;
            }
        }
    }
}
