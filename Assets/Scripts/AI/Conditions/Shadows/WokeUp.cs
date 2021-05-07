using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Shadows/Woke Up")]
public class WokeUp : Condition
{
    public override bool Validate(FSM entity)
    {
        return entity.GetAgent().imaginaryFriend.InitialSleepTimer <= 0f;
    }
}
