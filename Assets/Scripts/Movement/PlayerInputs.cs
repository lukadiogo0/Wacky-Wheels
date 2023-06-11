using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, IDecisions
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
}
