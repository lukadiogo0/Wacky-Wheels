using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI raceEndText;
    [SerializeField] private Button playAgainButton;


    private void Awake() {
        playAgainButton.onClick.AddListener(() => {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start() {
        WackyGameManager.Instance.OnStateChanged += WackyGameManager_OnStateChanged;

        Hide();
    }

    private void WackyGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (WackyGameManager.Instance.IsRaceEnd()) {
            Show();

            raceEndText.text = "You Lose";
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
        playAgainButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}