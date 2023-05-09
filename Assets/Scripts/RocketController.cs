using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform rocketSpawnPoint;
    public float rocketSpeed = 10f;
    public Sprite defaultSprite;

    public static bool hasRocketPowerup = false; // added this variable
    public static bool rocketHasBeenUsed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasRocketPowerup) // modified this line
        {
            // Spawn the rocket prefab at the rocket spawn point
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation);

            // Get the rigidbody component of the rocket
            Rigidbody rb = rocket.GetComponent<Rigidbody>();

            // Set the velocity of the rocket
            rb.velocity = transform.forward * rocketSpeed;

            // reset the rocket power-up flag to false
            hasRocketPowerup = false;

            rocketHasBeenUsed = true;
        }
    }
}
