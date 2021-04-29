using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Chase")]
public class ChaseAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().SetDestinationTo(entity.GetAgent().player.transform.position);
        entity.GetAgent().UpdateSpeed(entity.GetAgent().Shadow.ChasingSpeed);
        entity.GetAgent().Shadow.LastPlayerPosition = entity.GetAgent().player.transform.position;
        entity.GetAgent().Shadow.InitialChaseTimer -= Time.deltaTime;
        Debug.Log(entity.GetAgent().Shadow.InitialChaseTimer);
    }
}
