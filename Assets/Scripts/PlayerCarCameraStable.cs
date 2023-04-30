using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCameraStable : MonoBehaviour
{

    public GameObject PlayerCar;
    public float PlayerCarX;
    public float PlayerCarY;
    public float PlayerCarZ;

    void Update()
    {
        PlayerCarX = PlayerCar.transform.eulerAngles.x;
        PlayerCarY = PlayerCar.transform.eulerAngles.y;
        PlayerCarZ = PlayerCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(PlayerCarX - PlayerCarX, PlayerCarY, PlayerCarZ - PlayerCarZ);
    }
}
