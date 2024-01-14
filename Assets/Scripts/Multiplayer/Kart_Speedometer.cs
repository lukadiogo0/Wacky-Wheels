using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Kart_Speedometer : NetworkBehaviour
{
    private KartController_Multiplayer kartController;
    public GameObject needle;
    private float startPosition = 220f,endPosition = -46f;
    private float desiredPosition;

    private float vehicleSpeed;

    private void Start()
    {
        kartController = GetComponent<KartController_Multiplayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (!IsOwner) return;
       needle.SetActive(true);
        vehicleSpeed = kartController.CurrentSpeed;
       if(vehicleSpeed < 0)
        {
            vehicleSpeed = 0;
        }
       updateNeedle();
    }

    public void updateNeedle(){
        desiredPosition = startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        needle.transform.eulerAngles = new Vector3(0,0,(startPosition - temp * desiredPosition));
    }
}
