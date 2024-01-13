using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForOtherPlayersUI : MonoBehaviour {


    private void Start() {
        WackyGameManager.Instance.OnLocalPlayerReadyChanged += WackyGameManager_OnLocalPlayerReadyChanged;
        WackyGameManager.Instance.OnStateChanged += WackyGameManager_OnStateChanged;

        Hide();
    }

    private void WackyGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (WackyGameManager.Instance.IsCountdownToStartActive()) {
            Hide();
        }
    }

    private void WackyGameManager_OnLocalPlayerReadyChanged(object sender, System.EventArgs e) {
        if (WackyGameManager.Instance.IsLocalPlayerReady()) {
            Show();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}