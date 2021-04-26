using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Imaginary Friends/Interact With Player")]
public class InteractWithPlayer : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().PauseAgent();
        entity.GetAgent().transform.LookAt(entity.GetAgent().player.transform.position);
    }
}
