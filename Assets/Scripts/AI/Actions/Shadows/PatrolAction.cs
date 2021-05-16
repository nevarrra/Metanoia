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
        if(entity.GetAgent().imaginaryFriend.ID == 3 && entity.GetAgent().ReachedGoal())
        {
            entity.GetAgent().RandomizeTargets();
        }

    }
}
