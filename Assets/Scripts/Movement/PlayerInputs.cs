using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, IDecisions
{
    public float Turn()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool Accelerate()
    {
        if(Input.GetAxis("Accelerate") > 0)
        {
            return true;
        }
        return false;
    }

    public bool Brake()
    {
        if (Input.GetAxis("Brake") > 0)
        {
            return true;
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
