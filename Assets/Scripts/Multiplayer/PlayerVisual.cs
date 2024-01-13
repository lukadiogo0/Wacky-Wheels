using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer bodyMeshRenderer;


    private Material material;

    private void Awake()
    {
        material = new Material(bodyMeshRenderer.materials[0]);
        bodyMeshRenderer.material = material;
    }

    public void SetPlayerColor(Material material)
    {
        bodyMeshRenderer.material = material;
    }
}
