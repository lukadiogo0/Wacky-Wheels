using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{
    public float boostPower = 20f;
    public float boostDuration = 2f;
    public AudioClip propulsorSound;  



    private KartController kartController;
    private float originalSpeed;
    private float newSpeed;
    public static bool hasPropulsorPowerup = false;
    public static bool propulsorHasBeenUsed = false;
    private AudioSource audioSource;




    void Start()
    {
        kartController = GetComponent<KartController>();
        audioSource = GetComponent<AudioSource>();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasPropulsorPowerup)
        {
            ActivatePropulsor();
        }

    }

    private void ActivatePropulsor()
    {
        hasPropulsorPowerup = false;
        propulsorHasBeenUsed = true;


        // Save the original speed
        originalSpeed = kartController.CurrentSpeed;

        // Apply the speed boost to the kart
        newSpeed = kartController.CurrentSpeed += boostPower;
        audioSource.PlayOneShot(propulsorSound);


        // Invoke a method to restore the original speed after the boost duration
        Invoke(nameof(RestoreSpeed), boostDuration);
    }

    private void RestoreSpeed()
    {
        // Restore the original speed
        if(kartController.CurrentSpeed > 60){
            kartController.CurrentSpeed = 60;
        }else{
            kartController.CurrentSpeed = newSpeed;
        }
        propulsorHasBeenUsed = false;
    }
}
