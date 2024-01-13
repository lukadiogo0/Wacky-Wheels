using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarColorSelectSingleUI : MonoBehaviour {


    [SerializeField] private int colorId;
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedGameObject;


    private void Awake() {
        GetComponent<Button>().onClick.AddListener(() => {
            WackyGameMultiplayer.Instance.ChangePlayerColor(colorId);
        });
    }

    private void Start() {
        WackyGameMultiplayer.Instance.OnPlayerDataNetworkListChanged += WackyGameMultiplayer_OnPlayerDataNetworkListChanged;
        //image.color = WackyGameMultiplayer.Instance.GetPlayerColor(colorId);
        UpdateIsSelected();
    }

    private void WackyGameMultiplayer_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e) {
        UpdateIsSelected();
    }

    private void UpdateIsSelected() {
        if (WackyGameMultiplayer.Instance.GetPlayerData().colorId == colorId) {
            selectedGameObject.SetActive(true);
        } else {
            selectedGameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        WackyGameMultiplayer.Instance.OnPlayerDataNetworkListChanged -= WackyGameMultiplayer_OnPlayerDataNetworkListChanged;
    }
}