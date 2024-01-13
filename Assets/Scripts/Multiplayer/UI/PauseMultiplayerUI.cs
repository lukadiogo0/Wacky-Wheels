using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMultiplayerUI : MonoBehaviour {



    private void Start() {
        WackyGameManager.Instance.OnMultiplayerGamePaused += WackyGameManager_OnMultiplayerGamePaused;
        WackyGameManager.Instance.OnMultiplayerGameUnpaused += WackyGameManager_OnMultiplayerGameUnpaused;

        Hide();
    }

    private void WackyGameManager_OnMultiplayerGameUnpaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void WackyGameManager_OnMultiplayerGamePaused(object sender, System.EventArgs e) {
        Show();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}