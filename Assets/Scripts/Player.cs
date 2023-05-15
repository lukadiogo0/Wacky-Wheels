using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CheckpointManager CheckpointManager;
    private int lapCounter = 0;
    private int checkpointCounter = 0;


    private void OnTriggerEnter(Collider other)
    {
        Checkpoint checkpoint = other.gameObject.GetComponent<Checkpoint>();
        if (checkpoint != null)
        {
            int checkpointIndex = checkpoint.index;
            if (checkpointIndex == 0 && checkpointCounter == CheckpointManager.checkpoints.Length - 1)
            {
                // The car has passed through all of the checkpoints and then passed through the first one again, so increment the lap counter and reset the checkpoint counter.
                lapCounter++;
                checkpointCounter = 0;
                Debug.Log("Lap " + lapCounter + " completed!");
            }
            else
            {
                Debug.Log("Checkpoint " + lapCounter + " completed!");

                checkpointCounter++;
            }
            CheckpointManager.SetLastCheckpointPassed(checkpointIndex);
        }
    }

    public int GetLapCounter()
    {
        return lapCounter;
    }
  
}