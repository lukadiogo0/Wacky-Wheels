using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // The speed of the enemy

    private Vector3 forwardDirection; // The initial forward direction

    void Start()
    {
        // Store the initial forward direction
        forwardDirection = transform.forward;
    }

    void Update()
    {
        // Move the enemy forward
        transform.position += forwardDirection * speed * Time.deltaTime;
        Debug.Log(speed);
    }
}
