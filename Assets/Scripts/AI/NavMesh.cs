using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array of all the waypoints in the desired order
    private int currentWaypointIndex = 0; // Current index of the waypoint the AI is moving towards
    private NavMeshAgent navMeshAgent;
    private bool canMove = false;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        SetNextWaypoint();
    }

    void SetNextWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
            currentWaypointIndex++;
        }
        else
        {
            currentWaypointIndex = 0;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    void Update()
    {
        if (canMove)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = false;
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.pathPending)
                {
                    SetNextWaypoint();
                }
            }
        }
        else
        {
            navMeshAgent.enabled = false;
            //navMeshAgent.isStopped = true;
            //navMeshAgent.velocity = Vector3.zero;
        }

        
        
    }
}
