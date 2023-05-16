using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, IDecisions
{
    public void Drift()
    {
        throw new System.NotImplementedException();
    }

    public float Turn()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool Accelerate()
    {
        if(Input.GetAxis("Vertical")!= 0)
        {
            return true;
        }
        return false;
    }
}
