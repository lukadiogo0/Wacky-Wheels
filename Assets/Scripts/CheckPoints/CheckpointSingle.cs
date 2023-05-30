using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {

    private TrackCheckpoints trackCheckpoints;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<KartController>(out KartController kart)) {
            trackCheckpoints.CarThroughCheckpoint(this, other.transform);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
