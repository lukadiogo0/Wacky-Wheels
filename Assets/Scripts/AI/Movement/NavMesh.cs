using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array of all the waypoints in the desired order
    private int currentWaypointIndex = 0; // Current index of the waypoint the AI is moving towards
    private NavMeshAgent navMeshAgent;

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
            // AI has reached the final waypoint or there are no waypoints left
            // You can handle this condition according to your game's logic
        }
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.pathPending)
            {
                SetNextWaypoint();
            }
        }
    }
}
