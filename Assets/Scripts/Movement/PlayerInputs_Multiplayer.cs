using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

/*public class PlayerInputs : MonoBehaviour, IDecisions
{

    public AudioClip audioClipAccelerate;
public AudioClip audioClipBrake;
public AudioClip audioClipDrift;

private AudioSource audioSource;
private KartController kartController;


private void Start()
{
    kartController = GetComponent<KartController>();
    audioSource = GetComponent<AudioSource>();
}

public bool Accelerate()
{
    if (Input.GetAxis("Accelerate") > 0)
    {
        // Play the accelerate sound
        if (!audioSource.isPlaying && kartController.CurrentSpeed > 0)
        {
            audioSource.clip = audioClipAccelerate;
            audioSource.volume = 0.05f;
            audioSource.Play();
        }

        return true;
    }

    // Stop playing the accelerate sound
    if (audioSource.isPlaying && audioSource.clip == audioClipAccelerate)
    {
        audioSource.Stop();
    }

    return false;
}
     public float Turn()
    {
        return Input.GetAxis("Horizontal");
    }

public bool Brake()
{
    
        if (Input.GetAxis("Brake") > 0)
        {
           
            // Play the brake sound
            if (!audioSource.isPlaying && kartController.CurrentSpeed > 0)
             {
                audioSource.clip = audioClipBrake;
                audioSource.Play();
            }
            
            return true;
        }

        // Stop playing the brake sound
        if (audioSource.isPlaying && audioSource.clip == audioClipBrake)
        {
            audioSource.Stop();
        }
    

    return false;
}

    public bool DriftAnim()
    {
        if (Input.GetButtonDown("Drift"))
        {
            return true;
        }
        return false;
    }

    public bool Drift()
    {
        if (Input.GetButton("Drift"))
        {
            return true;
        }
        return false;
    }
}*/

public class PlayerInputs_Multiplayer: NetworkBehaviour
{
    private KartController_Multiplayer kartController;
    /*public AudioClip audioClipAccelerate;
    public AudioClip audioClipBrake;
    public AudioClip audioClipDrift;
    private AudioSource audioSource;*/


    private void Awake()
    {
        kartController = GetComponent<KartController_Multiplayer>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (!IsOwner) return;
        bool isAccelerating = Input.GetAxisRaw("Accelerate") > 0 ? true : false;
        bool isBraking = Input.GetAxisRaw("Brake") > 0 ? true : false;
        float turnAmount = Input.GetAxisRaw("Horizontal");
        bool isSpacePressed = Input.GetButtonDown("Drift");
        bool isSpaceStillPressed = Input.GetButton("Drift");
        kartController.SetInputs(isAccelerating, isBraking, turnAmount, isSpacePressed, isSpaceStillPressed);
    }

}
