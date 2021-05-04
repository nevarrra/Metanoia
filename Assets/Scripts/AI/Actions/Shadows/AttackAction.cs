﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Attack")]
public class AttackAction : Action
{
    public override void Act(FSM entity)
    {
        //float dist = Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position);
        entity.GetAgent().imaginaryFriend.InitialChaseTimer = entity.GetAgent().imaginaryFriend.ChaseTimer;
        entity.GetAgent().imaginaryFriend.LastPlayerPosition = entity.GetAgent().player.transform.position;
        //entity.GetAgent().RotationSpeedExtra();

        //if (dist > entity.GetAgent().imaginaryFriend.AttackRange)
        //{
        //    entity.GetAgent().imaginaryFriend.ChasingSpeed *= 1.1f;
        //} else
        //{
        //    entity.GetAgent().UpdateSpeed(entity.GetAgent().player.GetComponent<ControlAndMovement>().movementSpeed);
        //    entity.GetAgent().player.GetComponent<ControlAndMovement>().IncreaseHeartbeat(entity.GetAgent().imaginaryFriend.Damage);
        //}

        entity.GetAgent().transform.position = entity.GetAgent().player.transform.position;

    }
}