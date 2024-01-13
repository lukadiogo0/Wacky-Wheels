using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectPlayer : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameObject readyGameObject;
    [SerializeField] private PlayerVisual playerVisual;
    [SerializeField] private Button kickButton;
    [SerializeField] private TextMeshPro playerNameText;

    private void Awake()
    {
        kickButton.onClick.AddListener(() => {
            PlayerData playerData = WackyGameMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            WackyGameLobby.Instance.KickPlayer(playerData.playerId.ToString());
            WackyGameMultiplayer.Instance.KickPlayer(playerData.clientId);
        });
    }

    private void Start()
    {
        WackyGameMultiplayer.Instance.OnPlayerDataNetworkListChanged += WackyGameMultiplayer_OnPlayerDataNetworkListChanged;
        CarSelectReady.Instance.OnReadyChanged += CarSelectReady_OnReadyChanged;

        kickButton.gameObject.SetActive(NetworkManager.Singleton.IsServer);

        UpdatePlayer();
    }

    private void CarSelectReady_OnReadyChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void WackyGameMultiplayer_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        if (WackyGameMultiplayer.Instance.IsPlayerIndexConnected(playerIndex))
        {
            Show();

            PlayerData playerData = WackyGameMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);

            readyGameObject.SetActive(CarSelectReady.Instance.IsPlayerReady(playerData.clientId));

            playerNameText.text = playerData.playerName.ToString();

            playerVisual.SetPlayerColor(WackyGameMultiplayer.Instance.GetPlayerMaterial(playerData.colorId));
        }
        else
        {
            Hide();
        }
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
        WackyGameMultiplayer.Instance.OnPlayerDataNetworkListChanged -= WackyGameMultiplayer_OnPlayerDataNetworkListChanged;
    }

}
