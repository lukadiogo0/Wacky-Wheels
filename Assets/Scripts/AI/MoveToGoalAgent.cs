using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoalAgent : Agent, IDecisions
{

   [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform CarTransform;
    private float accelerate = 0f;
    private float turn = 0f;

    public bool Accelerate()
    {
        if(accelerate > 0)
        {
            return true;
        }
        return false;
    }

    public bool Brake()
    {
        throw new System.NotImplementedException();
    }

    
    public bool Drift()
    {
        throw new System.NotImplementedException();
    }

    public bool DriftAnim()
    {
        throw new System.NotImplementedException();
    }

    public float Turn()
    {
        return turn;
    }


    public override void OnEpisodeBegin()
    {
        CarTransform.position = new Vector3(686.3f, 61.36f, 446.67f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(CarTransform.position);//posicao da ai
        sensor.AddObservation(targetTransform.position); //posicao do objetivo
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        accelerate = actions.DiscreteActions[0];
        turn = actions.DiscreteActions[1];
    }

    public void OnCollisionEnter(Collision collision)
    {
        AddReward(1f);
        EndEpisode();
    }
}
