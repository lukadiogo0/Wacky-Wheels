using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarCameraStable : MonoBehaviour
{

    /*public GameObject PlayerCar;
    public float PlayerCarX;
    public float PlayerCarY;
    public float PlayerCarZ;

    void Update()
    {
        PlayerCarX = PlayerCar.transform.eulerAngles.x;
        PlayerCarY = PlayerCar.transform.eulerAngles.y;
        PlayerCarZ = PlayerCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(PlayerCarX - PlayerCarX, PlayerCarY, PlayerCarZ - PlayerCarZ);
    }*/

    public Vector3 offset;
    public Transform player;

    private KartController kartController;

    public Vector3 origCamPos;
    public Vector3 boostCamPos;

    // Start is called before the first frame update
    void Start()
    {
        kartController = player.GetComponent<KartController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, 3 * Time.deltaTime); //normal


        if (kartController.BoostTime > 0)
        {
            transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, boostCamPos, 3 * Time.deltaTime);
        }
        else
        {
            transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, origCamPos, 3 * Time.deltaTime);
        }
    }
}
