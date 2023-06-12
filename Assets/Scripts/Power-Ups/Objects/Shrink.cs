using UnityEngine;

public class Shrink : MonoBehaviour
{
    public float speed = 10f; // The speed at which the projectile moves
    public float lifetime = 5f; // The lifetime of the projectile
    public float shrinkAmount = 0.5f; // The amount by which the enemy shrinks
    public float shrinkDuration = 2f; // The duration of the shrink effect
    public float distanceFromGround = 1.5f;

    private Rigidbody rb;
    public AudioClip shrinkSound2;
    private AudioSource audioSource;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distance = hit.distance;
            if (distance < distanceFromGround)
            {
                transform.position += Vector3.up * (distanceFromGround - distance);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(shrinkSound2);
            ShrinkEnemy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ShrinkEnemy(GameObject enemy)
    {
        // Apply the shrink effect to the enemy
        Vector3 newScale = enemy.transform.localScale * (1f - shrinkAmount);
        enemy.transform.localScale = newScale;

        // Store the enemy's initial scale, velocity, and speed
        Vector3 initialScale = enemy.transform.localScale;
        Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
        Vector3 initialVelocity = enemyRigidbody.velocity;
        float initialSpeed = initialVelocity.magnitude;

        // Start a timer to restore the enemy's scale and speed
        ShrinkTimer timer = enemy.AddComponent<ShrinkTimer>();
        timer.ResetTimer(shrinkDuration, initialScale, enemyRigidbody, initialVelocity, shrinkAmount);
    }
    
}