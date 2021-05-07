﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Time Elapsed")]

public class TimeElapsed : Condition
{
    public override bool Validate(FSM entity)
    {
        if (entity.GetAgent().timer <= 0 && !entity.GetAgent().HasReachedFinalTarget())
        {
            return true;
        }
        return false;
    }
}
