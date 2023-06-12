
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{

    public GameObject CountDown;
    public AudioSource CountDownAudio;
    public GameObject LapTimer;
    [SerializeField] private KartController player;
    [SerializeField] private List<NavMesh> botsList;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<TextMeshProUGUI>().text = "3";
        CountDownAudio.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<TextMeshProUGUI>().text = "2";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<TextMeshProUGUI>().text = "1";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<TextMeshProUGUI>().text = "GO!";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);

        player.SetCanMove(true);
        foreach (NavMesh bot in botsList)
        {
            bot.SetCanMove(true);
        }

        LapTimer.SetActive(true);
        
    }
}
