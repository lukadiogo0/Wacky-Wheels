using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float despawnTime = 4f;
    public Transform spawnPoint;

    private GameObject currentObstacle;
    private float despawnTimer = 0f;
    public static bool isObstacleActive = false;
    public static bool obstacleHasBeenUsed = false;
    public static bool hasObstacle = false;

    public AudioClip ObstacleSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && hasObstacle == true)
        {
            ActivateObstacle();
        }

        if (isObstacleActive == true)
        {
            despawnTimer += Time.deltaTime;

            if (despawnTimer >= despawnTime)
            {
                Destroy(currentObstacle);
                isObstacleActive = false;
                obstacleHasBeenUsed = true;
                hasObstacle = false;
                despawnTimer = 0f;
            }
        }
    }

    private void ActivateObstacle()
    {
        currentObstacle = Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = currentObstacle.GetComponent<Rigidbody>();
        audioSource.PlayOneShot(ObstacleSound);
        isObstacleActive = true;
        obstacleHasBeenUsed = true;
        hasObstacle = false;
    }

    IEnumerator DestroyObstacleWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(currentObstacle);
        isObstacleActive = false;
        hasObstacle = false;
        despawnTimer = 0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isObstacleActive && collision.gameObject.tag == "Obstacle")
        {
            // Add some delay to simulate the impact
            StartCoroutine(DestroyObstacleWithDelay(0.5f));
        }
    }
}
