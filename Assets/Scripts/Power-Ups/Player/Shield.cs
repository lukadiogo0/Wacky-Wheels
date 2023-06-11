using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float barrierRadius = 5f; // Radius of the shield barrier
    public float shieldDuration = 3f; // Duration of the shield in seconds
    public GameObject shieldPrefab; // Prefab of the shield sphere

    public static bool isShieldActive = false;
    public static bool shieldHasBeenUsed = false;
    public static bool hasShield = false;
    private SphereCollider shieldCollider; // Reference to the shield's sphere collider

    private GameObject shieldSpawnPoint; // Reference to the shield spawn point
    private GameObject currentShield; // Reference to the current shield instance

    public AudioClip shieldSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shieldCollider = gameObject.AddComponent<SphereCollider>();
        shieldCollider.radius = barrierRadius;
        shieldCollider.isTrigger = true;
        shieldCollider.enabled = false; // Disable the collider initially

        shieldSpawnPoint = GameObject.Find("ShieldSpawnPoint"); // Find the ShieldSpawnPoint GameObject
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasShield == true)
        {
            ActivateShield();
            StartCoroutine(DeactivateShieldAfterDelay(shieldDuration));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isShieldActive && (other.CompareTag("PowerUp") || other.CompareTag("Obstacle")))
        {
            Destroy(other.gameObject); // Destroy the power-up instantly
        }
    }

    private void ActivateShield()
    {
         audioSource.PlayOneShot(shieldSound);
        isShieldActive = true;
        shieldHasBeenUsed = true;
        hasShield = false;
        shieldCollider.enabled = true; // Enable the collider to activate the shield barrier

        // Instantiate the shield prefab at the spawn point position and rotation
        currentShield = Instantiate(shieldPrefab, shieldSpawnPoint.transform.position, shieldSpawnPoint.transform.rotation);
        currentShield.transform.parent = transform; // Make the shield prefab a child of the car
    }

    private IEnumerator DeactivateShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isShieldActive = false;
        shieldHasBeenUsed = true;
        hasShield = false;
        shieldCollider.enabled = false; // Disable the collider to deactivate the shield barrier

        // Destroy the shield prefab after the delay
        Destroy(currentShield);
    }
}
