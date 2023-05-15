using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public float explosionRadius = 3f;
    public float explosionForce = 100f;
    public float distanceFromGround = 1.5f;

    private Rigidbody rb;
    private Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rb.useGravity = false;
        rb.velocity = transform.forward * speed;
        Debug.Log("SPEED");
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

    void OnCollisionEnter(Collision collision)
    {
        Explode();
        Debug.Log("BOOOM");
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }
}
