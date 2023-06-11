using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform rocketSpawnPoint;
    public float rocketSpeed = 10f;
    public Sprite defaultSprite;

    public static bool hasRocketPowerup = false;
    public static bool rocketHasBeenUsed = false;
    public AudioClip rocketSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasRocketPowerup)
        {
            // Spawn the rocket prefab at the rocket spawn point
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation);
            audioSource.PlayOneShot(rocketSound);

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
