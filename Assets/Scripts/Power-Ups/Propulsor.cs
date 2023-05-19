using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{
    public float propulsorSpeed = 2f;
    public float propulsorDuration = 5f;

    private float normalSpeed;
    private float propulsorTimer = 0f;
    public static bool hasPropulsorPowerup = false;
    public static bool propulsorHasBeenUsed = false;

    private Rigidbody carRigidbody;

    void Start()
    {
        // Get the car's rigidbody component
        carRigidbody = GetComponent<Rigidbody>();

        // Get the car's normal speed
        normalSpeed = carRigidbody.velocity.magnitude;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasPropulsorPowerup)
        {
            ActivatePropulsor();
        }

        if (propulsorHasBeenUsed)
        {
            propulsorTimer += Time.deltaTime;
            if (propulsorTimer >= propulsorDuration)
            {
                DeactivatePropulsor();
            }
        }
    }

    IEnumerator ApplyBoostForce(float boostSpeed)
    {
        float duration = 1f;
        float elapsedTime = 0f;
        float currentSpeed = carRigidbody.velocity.magnitude;
        float targetSpeed = currentSpeed + boostSpeed;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentForceMagnitude = carRigidbody.mass * (Mathf.Lerp(currentSpeed, targetSpeed, t) - currentSpeed) / Time.fixedDeltaTime;
            carRigidbody.AddForce(carRigidbody.transform.forward * currentForceMagnitude, ForceMode.Impulse);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    void ActivatePropulsor()
    {
        hasPropulsorPowerup = false;
        propulsorHasBeenUsed = true;

        // Calculate the boost speed by adding the propulsor speed to the car's current speed
        float boostSpeed = propulsorSpeed;

        // Apply the force to the car's rigidbody gradually over time
        StartCoroutine(ApplyBoostForce(boostSpeed));

    }




    void DeactivatePropulsor()
    {
        propulsorHasBeenUsed = false;

        // Set the car's rigidbody velocity back to its normal speed
        carRigidbody.velocity = carRigidbody.velocity.normalized * normalSpeed;


        propulsorTimer = 0f;
    }
}
