using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkController : MonoBehaviour
{
    public GameObject shrinkPrefab;
    public Transform shrinkSpawnPoint;
    public float shrinkSpeed = 10f;
    public Sprite defaultSprite;

    public static bool hasShrinkPowerup = false;
    public static bool shrinkHasBeenUsed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasShrinkPowerup)
        {
            // Spawn the shrink prefab at the shrink spawn point
            GameObject shrink = Instantiate(shrinkPrefab, shrinkSpawnPoint.position, shrinkSpawnPoint.rotation);

            // Get the rigidbody component of the shrink projectile
            Rigidbody rb = shrink.GetComponent<Rigidbody>();

            // Set the velocity of the shrink projectile
            rb.velocity = transform.forward * shrinkSpeed;

            // Reset the shrink power-up flag to false
            hasShrinkPowerup = false;

            shrinkHasBeenUsed = true;
        }
    }
}
