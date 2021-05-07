using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Imaginary Friends/Stroll To Idle")]
public class StrollToIdle : Condition
{
    public override bool Validate(FSM entity)
    {

        if (entity.GetAgent().HasReachedEndOfPathOrNoPath())
        {
            entity.GetAgent().UpdateTargets();
            return true;
        }

        return false;
             
    }

   
}
