using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{

    public event EventHandler<CarCheckPointEventArgs> OnCarCorrectCheckpoint;
    public event EventHandler<CarCheckPointEventArgs> OnCarWrongCheckpoint;

    [SerializeField] private List<Transform> carTransformList;

    private List<CheckpointSingle> checkpointSingleList;
    private List<Transform> checkpointSingleTransforms;
    private List<int> nextCheckpointSingleIndexList;

    public Transform checkpoints;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndexList = new List<int>();
        foreach (Transform carTransform in carTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }


    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform)
    {
        int nextCheckpointSingleIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            // Correct checkpoint
            if (OnCarCorrectCheckpoint != null)
            {
                CarCheckPointEventArgs args = new CarCheckPointEventArgs(carTransform);
                
                OnCarCorrectCheckpoint.Invoke(this, args);
            }
            Debug.Log("Correct Checkpoint");
            nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)]
                = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
        }
        else
        {
            Debug.Log("Wrong Checkpoint");
            // Wrong checkpoint
            if (OnCarWrongCheckpoint != null)
            {
                CarCheckPointEventArgs args = new CarCheckPointEventArgs(carTransform);
                OnCarWrongCheckpoint.Invoke(this, args);
            }
        }
    }

    public Transform GetNextCheckpoint(Transform carTransform)
    {
        Transform nextCheckpointTransform = null;

        int nextCheckpointIndex = nextCheckpointSingleIndexList[carTransformList.IndexOf(carTransform)];
        if(nextCheckpointIndex != -1) { 
            nextCheckpointTransform = checkpointSingleTransforms[nextCheckpointIndex];
        }
        /*float closestDistance = Mathf.Infinity;

        // Itera pelos checkpoints para encontrar o mais próximo da posição atual
        foreach (Transform checkpoint in checkpoints)
        {
            float distance = Vector3.Distance(currentPosition.position, checkpoint.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nextCheckpoint = checkpoint;
            }
        }*/
        return nextCheckpointTransform;
    }

    public void ResetCheckpoint(Transform carTransform)
    {
        int carIndex = carTransformList.IndexOf(carTransform);
        if (carIndex != -1)
        {
            nextCheckpointSingleIndexList[carIndex] = 0;
        }
    }

    public int FindCheckpointIndex(Transform carTransform)
    {
        int carIndex = carTransformList.IndexOf(carTransform);
        if (carIndex != -1)
        {
            return nextCheckpointSingleIndexList[carIndex];
        }
        return -1;
    }

    public class CarCheckPointEventArgs : EventArgs
    {
        public Transform carTransform;

        public CarCheckPointEventArgs(Transform carTransform)
        {
            this.carTransform = carTransform;
        }
    }
}
