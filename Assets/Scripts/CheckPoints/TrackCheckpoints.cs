using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    [SerializeField] private Transform playerCarTransform;
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;
    private bool isCooldown;

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

        nextCheckpointSingleIndex = 0;
        isCooldown = false;
    }

    private void Update()
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
    }

    private IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f); // Cooldown duration in seconds
        isCooldown = false;
    }

    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform)
    {
        if (carTransform == playerCarTransform)
        {
            int nextCheckpointSingleIndex = checkpointSingleList.IndexOf(checkpointSingle);
            if (nextCheckpointSingleIndex == this.nextCheckpointSingleIndex)
            {
                

                this.nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            }
            else
            {
                
            }
        }
    }
}
