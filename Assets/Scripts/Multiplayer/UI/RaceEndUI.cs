using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceEndUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI raceEndText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake() {
        nextLevelButton.onClick.AddListener(() => {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    Loader.Load(Loader.Scene.Level2);
                    break;
                case "Level2":
                    Loader.Load(Loader.Scene.Level3);
                    break;
                case "Level3":
                    Loader.Load(Loader.Scene.Level4);
                    break;
                case "Level4":
                    NetworkManager.Singleton.Shutdown();
                    Loader.Load(Loader.Scene.MainMenuScene);
                    break;
                default:
                    NetworkManager.Singleton.Shutdown();
                    Loader.Load(Loader.Scene.MainMenuScene);
                    break;
            }
        });

        mainMenuButton.onClick.AddListener(() =>
        {
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
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
        nextLevelButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}