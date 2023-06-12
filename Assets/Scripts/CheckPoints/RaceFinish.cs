using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class RaceFinish : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bot;
    public GameObject Camera;
    public GameObject TextWin;
    public GameObject TextLose;
    public GameObject TextFinalPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart))
        {
            Debug.Log("Acabou");
            TextFinalPosition.SetActive(true);
            TextFinalPosition.GetComponent<TextMeshProUGUI>().text = TextFinalPosition.GetComponent<TextMeshProUGUI>().text + " " + kart.position;
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                if (kart.position <= 3)
                {
                    TextWin.SetActive(true);
                }
                else
                {
                    TextLose.SetActive(true);
                }
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                if (kart.position <= 3)
                {
                    TextWin.SetActive(true);
                }
                else
                {
                    TextLose.SetActive(true);
                }
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                if (kart.position <= 2)
                {
                    TextWin.SetActive(true);
                }
                else
                {
                    TextLose.SetActive(true);
                }
            }
            if (SceneManager.GetActiveScene().name == "Level4")
            {
                if (kart.position <= 1)
                {
                    TextWin.SetActive(true);
                }
                else
                {
                    TextLose.SetActive(true);
                }
            }
            Bot.GetComponent<Transform>().position = Player.GetComponent<Transform>().position;
            Bot.GetComponent<Transform>().rotation = Player.GetComponent<Transform>().rotation;
            Camera.GetComponent<PlayerCarCameraStable>().player = Bot.GetComponent<Transform>();
            Player.SetActive(false);
            Bot.SetActive(true); 
            Bot.GetComponent<NavMeshAgent>().enabled = false;
            NavMeshAgent botagent = Bot.GetComponent<NavMeshAgent>();
            NavMesh botascript = Bot.GetComponent<NavMesh>();
            botagent.enabled = true;
            botascript.enabled = true;
            botascript.SetCanMove(true);
            
        }
    }
}
