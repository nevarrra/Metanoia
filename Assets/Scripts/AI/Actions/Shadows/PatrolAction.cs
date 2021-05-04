using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Patrol")]
public class PatrolAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().imaginaryFriend.InitialSearchTimer = entity.GetAgent().imaginaryFriend.SearchTimer;
        entity.GetAgent().Patrol();
        //entity.GetAgent().targets.Clear();
        //entity.GetAgent().targets.Add(entity.GetAgent().waypoints[Random.Range(0, entity.GetAgent().waypoints.Count)]);
    }
}
