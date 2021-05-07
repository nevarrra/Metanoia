using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Reset Sleep")]
public class ResetSleepTimer : Action
{
    public override void Act(FSM entity)
    {
        entity.GetAgent().imaginaryFriend.InitialSleepTimer = entity.GetAgent().imaginaryFriend.SleepTimer;
    }
}
