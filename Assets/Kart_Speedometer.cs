using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart_Speedometer : MonoBehaviour
{
    private KartController kartController;
    public GameObject needle;
    private float startPosition = 220f,endPosition = -46f;
    private float desiredPosition;

    private float vehicleSpeed;

    private void Start()
    {
        kartController = GetComponent<KartController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
