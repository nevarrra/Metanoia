using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Attack")]
public class AttackAction : Action
{
    public override void Act(FSM entity)
    {

        //if (dist > entity.GetAgent().imaginaryFriend.AttackRange)
        //{
        //    entity.GetAgent().imaginaryFriend.ChasingSpeed *= 1.1f;
        //} else
        //{
        //    entity.GetAgent().UpdateSpeed(entity.GetAgent().player.GetComponent<ControlAndMovement>().movementSpeed);
        //    entity.GetAgent().player.GetComponent<ControlAndMovement>().IncreaseHeartbeat(entity.GetAgent().imaginaryFriend.Damage);
        //}
        if (entity.GetAgent().imaginaryFriend.ID == ShadowsID.Rabbit)
        {
            //Rabbit
            entity.GetAgent().imaginaryFriend.InitialChaseTimer = entity.GetAgent().imaginaryFriend.ChaseTimer;
            entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
            entity.GetAgent().SetDestinationTo(entity.GetAgent().player.transform.position);
            //entity.GetComponent<MeshRenderer>().enabled = true;
            entity.GetComponent<LightShadowRay>().meshActive = true;
            //entity.GetAgent().animalSFX.Play();
        }
        else
        {
            //Others
            entity.GetAgent().imaginaryFriend.InitialChaseTimer = entity.GetAgent().imaginaryFriend.ChaseTimer;
            entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
            entity.GetAgent().transform.position = entity.GetAgent().player.transform.position;
            //entity.GetComponent<MeshRenderer>().enabled = false;
            entity.GetComponent<LightShadowRay>().meshActive = false;
        }
    }
}
