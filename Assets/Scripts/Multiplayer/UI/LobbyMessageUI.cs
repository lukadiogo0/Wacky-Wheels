using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;


    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    private void Start()
    {
        WackyGameMultiplayer.Instance.OnFailedToJoinGame += WackyGameMultiplayer_OnFailedToJoinGame;
        WackyGameLobby.Instance.OnCreateLobbyStarted += WackyGameLobby_OnCreateLobbyStarted;
        WackyGameLobby.Instance.OnCreateLobbyFailed += WackyGameLobby_OnCreateLobbyFailed;
        WackyGameLobby.Instance.OnJoinStarted += WackyGameLobby_OnJoinStarted;
        WackyGameLobby.Instance.OnJoinFailed += WackyGameLobby_OnJoinFailed;
        WackyGameLobby.Instance.OnQuickJoinFailed += WackyGameLobby_OnQuickJoinFailed;

        Hide();
    }

    private void WackyGameLobby_OnQuickJoinFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Could not find a Lobby to Quick Join!");
    }

    private void WackyGameLobby_OnJoinFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to join Lobby!");
    }

    private void WackyGameLobby_OnJoinStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Joining Lobby...");
    }

    private void WackyGameLobby_OnCreateLobbyFailed(object sender, System.EventArgs e)
    {
        ShowMessage("Failed to create Lobby!");
    }

    private void WackyGameLobby_OnCreateLobbyStarted(object sender, System.EventArgs e)
    {
        ShowMessage("Creating Lobby...");
    }

    private void WackyGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        if (NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        WackyGameMultiplayer.Instance.OnFailedToJoinGame -= WackyGameMultiplayer_OnFailedToJoinGame;
        WackyGameLobby.Instance.OnCreateLobbyStarted -= WackyGameLobby_OnCreateLobbyStarted;
        WackyGameLobby.Instance.OnCreateLobbyFailed -= WackyGameLobby_OnCreateLobbyFailed;
        WackyGameLobby.Instance.OnJoinStarted -= WackyGameLobby_OnJoinStarted;
        WackyGameLobby.Instance.OnJoinFailed -= WackyGameLobby_OnJoinFailed;
        WackyGameLobby.Instance.OnQuickJoinFailed -= WackyGameLobby_OnQuickJoinFailed;
    }
}
