using UnityEngine;

public class ShrinkTimer : MonoBehaviour
{
    private float timer; // Timer to track the duration of the shrink effect
    private Vector3 initialScale; // The initial scale of the enemy
    private Rigidbody enemyRigidbody; // Reference to the enemy's rigidbody
    private Vector3 initialVelocity; // The initial velocity of the enemy
    private float shrinkAmount; // The amount by which the enemy shrinks

    public void ResetTimer(float duration, Vector3 initialScale, Rigidbody enemyRigidbody, Vector3 initialVelocity, float shrinkAmount)
    {
        timer = duration;
        this.initialScale = initialScale;
        this.enemyRigidbody = enemyRigidbody;
        this.initialVelocity = initialVelocity;
        this.shrinkAmount = shrinkAmount;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Restore the enemy's scale and speed by adding back what was taken out
                Vector3 restoredScale = initialScale + (initialScale * 2 * shrinkAmount);
                transform.localScale = restoredScale;
                enemyRigidbody.velocity = initialVelocity;

                Destroy(this);
            }
        }
    }
}