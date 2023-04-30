using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;


public class UITextFollowCamera : MonoBehaviour
{
    public Transform target;
    public Camera camera;
    public Player player;
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        Debug.Log("textMesh: " + textMesh);
    }
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        Debug.Log("textMesh: " + textMesh);
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
            return;
        }
        if (target == null || camera == null || textMesh == null)
        {
            return;
        }
        

        Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        transform.position = screenPos;
        textMesh.text = "Lap: " + player.GetLapCounter();
    }
}