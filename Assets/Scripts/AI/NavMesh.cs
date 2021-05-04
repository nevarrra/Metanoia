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
    public GameObject player;
    public Attributes imaginaryFriend;
    public float extraRotationSpeed = 10f;

    public void MoveAgent()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currWaypoint++;
            SetDestination();
        } 

    }

    public Waypoints GetClosestWaypoint()
    {
        float minDist = Mathf.Infinity;
        Waypoints waypoint = null; 
        foreach (Waypoints wp in waypoints)
        {
            if (Vector3.Distance(agent.transform.position, wp.transform.position) < minDist)
            {
                minDist = Vector3.Distance(agent.transform.position, wp.transform.position);
                waypoint = wp;
            }
        }
        return waypoint;
    }

    public void Patrol()
    {
        
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && path.Count == 0)
        {
            path = Pathfinding.FindPath(GetClosestWaypoint(), targets[currTarget], waypoints);

            //    Debug.Log(currWaypoint + "  " + currTarget);

            //    if (currWaypoint > path.Count && currTarget < targets.Count)
            //    {
            //        UpdateTargets();
            //        UpdatePath();
            //    }
            //    else
            //    {
            //        currWaypoint++;
            //    }
            //    if (currWaypoint < path.Count - 1)
            //    {
            //        agent.SetDestination(path[currWaypoint].transform.position);
            //    }

            //}
            //else
            //{
            //    Debug.Log("Anything");
        }
        if(path.Count > 0 && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(path[currWaypoint].transform.position);
            if (currWaypoint < path.Count - 1)
            {
                currWaypoint++;
            }  
            else
            {
                if(currTarget < targets.Count -1)
                {
                    currTarget++;

                }
                else
                {
                    currTarget = 0;
                }
                path.Clear();
            }
                
        }
    }

    public void ResumeAgent()
    {
        agent.isStopped = false;
    }

    public void PauseAgent()
    {
        agent.isStopped = true;
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void UpdatePath()
    {
        Debug.Log(currWaypoint + "  " + currTarget);
        if(currWaypoint < path.Count)
        {
            path = Pathfinding.FindPath(path[currWaypoint], targets[currTarget], waypoints);
        }
        
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

    public void UpdateSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void RotationSpeedExtra()
    {
        Vector3 lookrotation = (agent.steeringTarget - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
    }

    public void SetDestinationTo(Vector3 target)
    {
        agent.SetDestination(target);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = Pathfinding.FindPath(origin, targets[currTarget], waypoints);
        timer = Random.Range(1, 5);
        agent.speed = imaginaryFriend.Speed; 

        //currTarget = 0;
        //currWaypoint = 0;
        //RotationSpeedExtra();

    }

    private void Update()
    {

    }
}
