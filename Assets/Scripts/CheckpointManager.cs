using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    private int lastCheckpointPassed = 0;

    public void SetLastCheckpointPassed(int checkpointIndex)
    {
        if (checkpointIndex == lastCheckpointPassed + 1 || (checkpointIndex == 0 && lastCheckpointPassed == checkpoints.Length - 1))
        {
            lastCheckpointPassed = checkpointIndex;
            Debug.Log("Checkpoint " + checkpointIndex + " passed!");
            // Play a sound effect or animation to indicate that the player has passed through the checkpoint.
        }
    }

    public int GetLastCheckpointPassed()
    {
        return lastCheckpointPassed;
    }
}