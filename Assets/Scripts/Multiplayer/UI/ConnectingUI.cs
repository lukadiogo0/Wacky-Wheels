using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{
    private void Start()
    {
        WackyGameMultiplayer.Instance.OnTryingToJoinGame += WackyGameMultiplayer_OnTryingToJoinGame;
        WackyGameMultiplayer.Instance.OnFailedToJoinGame += WackyGameManager_OnFailedToJoinGame;

        Hide();
    }

    private void WackyGameManager_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void WackyGameMultiplayer_OnTryingToJoinGame(object sender, System.EventArgs e)
    {
        Show();
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
        WackyGameMultiplayer.Instance.OnTryingToJoinGame -= WackyGameMultiplayer_OnTryingToJoinGame;
        WackyGameMultiplayer.Instance.OnFailedToJoinGame -= WackyGameManager_OnFailedToJoinGame;
    }
}
