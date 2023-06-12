using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaceFinish : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bot;
    public GameObject Camera;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KartController>(out KartController kart))
        {
            Debug.Log("Acabou");
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
