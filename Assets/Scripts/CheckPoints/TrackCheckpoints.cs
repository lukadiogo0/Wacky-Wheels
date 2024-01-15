using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{

    public event EventHandler<CarCheckPointEventArgs> OnCarCorrectCheckpoint;
    public event EventHandler<CarCheckPointEventArgs> OnCarWrongCheckpoint;

    [SerializeField] private List<Transform> carTransformList;
    [SerializeField] private Transform playerCarTransform;

    private List<CheckpointSingle> checkpointSingleList;
    private List<Transform> checkpointSingleTransforms;
    private List<int> nextCheckpointSingleIndexList;
    private int nextCheckpointSingleIndex;
    private bool isCooldown;

    public Transform checkpoints;

    public void StartCheckPointManager(List<GameObject> karts)
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        checkpointSingleTransforms = new List<Transform>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
            checkpointSingleTransforms.Add(checkpointSingleTransform);
        }

        nextCheckpointSingleIndexList = new List<int>();
        foreach(GameObject gameObject in karts)
        {
            carTransformList.Add(gameObject.transform);
        }

        foreach (Transform carTransform in carTransformList)
        {
            nextCheckpointSingleIndexList.Add(0);
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isCooldown)
        {
            int previousCheckpointIndex = (nextCheckpointSingleIndex - 1 + checkpointSingleList.Count) % checkpointSingleList.Count;
            int currentCheckpointIndex = (nextCheckpointSingleIndex + checkpointSingleList.Count) % checkpointSingleList.Count;

            if (currentCheckpointIndex != previousCheckpointIndex)
            {
                StartCoroutine(StartCooldown());

                Transform previousCheckpointTransform = checkpointSingleList[previousCheckpointIndex].transform;
                Vector3 spawnPosition = previousCheckpointTransform.position;
                Quaternion spawnRotation = Quaternion.LookRotation(-previousCheckpointTransform.right); // Look in the opposite direction along the X-axis

                playerCarTransform.position = spawnPosition;
                playerCarTransform.rotation = spawnRotation;

                nextCheckpointSingleIndex = previousCheckpointIndex;

                Debug.Log("Passed Checkpoint: " + checkpointSingleList[previousCheckpointIndex].name);
            }
        }
    }*/

    private IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f); // Cooldown duration in seconds
        isCooldown = false;
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
        if (nextCheckpointIndex != -1) { 
            nextCheckpointTransform = checkpointSingleTransforms[nextCheckpointIndex];
        }
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
