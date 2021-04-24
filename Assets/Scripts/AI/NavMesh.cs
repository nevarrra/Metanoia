using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public List<Waypoints> waypoints;
    private NavMeshAgent agent;
    private int currWaypoint;
    //public Waypoints target;
    public Waypoints origin;
    private List<Waypoints> path;
    public float timer;
    public List<Waypoints> targets;
    private int currTarget;

    public void MoveAgent()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currWaypoint++;
            SetDestination();
        } 

    }

    public void ResumeAgent()
    {
        agent.isStopped = false;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void UpdatePath()
    {
        path = Pathfinding.FindPath(path[currWaypoint], targets[currTarget], waypoints);
        currWaypoint = 0;
    }

    public void UpdateTargets()
    {
        currTarget++;
    }

    public bool IsAtDestination()
    {
        return Vector3.Distance(agent.transform.position, targets[currTarget].transform.position) <= 2f && currTarget < targets.Count;      
    }

    public bool ReachedGoal()
    {
        if (Vector3.Distance(agent.transform.position, targets[targets.Count - 1].transform.position) <= 2f)
        {            
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ReachedOrigin()
    {
        if (Vector3.Distance(agent.transform.position, origin.transform.position) <= 2f)
        {
            currTarget = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GoBack()
    {
        path = Pathfinding.FindPath(path[currWaypoint], origin, waypoints);
        currWaypoint = 0;
        MoveAgent();
    }

    private void SetDestination()
    {
        try
        {
            agent.SetDestination(path[currWaypoint].transform.position);
        }
        catch (System.Exception ex) //Plan B
        {

            Debug.Log(ex.Message);
        } 
           
    }  

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = Pathfinding.FindPath(origin, targets[currTarget], waypoints);
        timer = Random.Range(1, 5);
        Debug.Log(path);

    }

    private void Update()
    {
    }
}
