using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Stroll")]
public class StrollAction : Action
{

    public override void Act(FSM entity)
    {
        entity.GetAgent().MoveAgent();
    }
}
