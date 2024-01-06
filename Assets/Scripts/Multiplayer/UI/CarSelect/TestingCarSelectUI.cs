using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingCarSelectUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;


    private void Awake()
    {
        readyButton.onClick.AddListener(() => {
            CarSelectReady.Instance.SetPlayerReady();
        });
    }
}
