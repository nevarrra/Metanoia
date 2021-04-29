using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Can Attack")]
public class CanAttack : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().Shadow.ChaseTimer <= 0;
    }
}
