using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour {

    private TrackCheckpoints trackCheckpoints;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<KartController_Multiplayer>(out KartController_Multiplayer kart)) {
            trackCheckpoints.CarThroughCheckpoint(this, kart.gameObject.transform);
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints) {
        this.trackCheckpoints = trackCheckpoints;
    }
}
