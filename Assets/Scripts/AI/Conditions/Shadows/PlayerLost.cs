﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Player Lost")]
public class PlayerLost : Condition
{
    public override bool Validate(FSM entity)
    {
        return Vector3.Distance(entity.GetAgent().transform.position, entity.GetAgent().player.transform.position) > entity.GetAgent().imaginaryFriend.VisionRange || entity.GetAgent().player.GetComponent<ControlAndMovement>().CollidedWithLight();
        
    }
}
