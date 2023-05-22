using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{
    public float boostPower = 20f;
    public float boostDuration = 2f;

    private KartController kartController;
    private float originalSpeed;
    public static bool hasPropulsorPowerup = false;
    public static bool propulsorHasBeenUsed = false;


    void Start()
    {
        kartController = GetComponent<KartController>();
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
        kartController.CurrentSpeed += boostPower;

        // Invoke a method to restore the original speed after the boost duration
        Invoke(nameof(RestoreSpeed), boostDuration);
    }

    private void RestoreSpeed()
    {
        // Restore the original speed
        kartController.CurrentSpeed = originalSpeed;
        propulsorHasBeenUsed = false;
    }
}
