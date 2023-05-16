using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour, IDecisions
{
    //o AI stá sempre a tentar olhar para o proximo waypoint
    //para isso vai ter de decidir fazer turns normais ou com drift
    //
    public void Drift()
    {
        throw new System.NotImplementedException();
    }

    public float Turn()
    {
        return 0f;
    }

    public bool Accelerate()
    {
        return false;
    }
}
