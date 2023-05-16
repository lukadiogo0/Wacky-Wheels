using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDecisions
{
    public float Turn();
    public bool Accelerate();
    public void Drift();
}
