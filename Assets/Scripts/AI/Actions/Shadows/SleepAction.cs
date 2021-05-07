using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Sleep")]
public class SleepAction : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().PauseAgent();
        entity.GetAgent().imaginaryFriend.InitialSleepTimer -= Time.deltaTime;
    }
}
