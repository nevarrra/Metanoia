using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Attack")]
public class AttackAction : Action
{
    public override void Act(FSM entity)
    {
        float dist = Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position);
        entity.GetAgent().Shadow.InitialChaseTimer = entity.GetAgent().Shadow.ChaseTimer;
        if (dist > entity.GetAgent().Shadow.AttackRange)
        {
            entity.GetAgent().Shadow.ChasingSpeed *= 1.5f;
        }
        if(dist <= entity.GetAgent().Shadow.AttackRange)
        {
            entity.GetAgent().UpdateSpeed(entity.GetAgent().player.GetComponent<ControlAndMovement>().movementSpeed);
            entity.GetAgent().player.GetComponent<ControlAndMovement>().IncreaseHeartbeat(entity.GetAgent().Shadow.Damage);
        }
        
    }
}
