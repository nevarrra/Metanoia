using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transition")]
public class Transition : ScriptableObject
{
    // Edirlei's generic code: 

    [SerializeField]
    private Condition decision;

    [SerializeField]
    private Action action;

    [SerializeField]
    private State targetState;

    public bool IsTriggered(FSM entity)
    {
        return decision.Validate(entity); // IsTriggered receives the agent to which the FSM code is attached (entity) and validates its condition to see if it's true or false to proceed to next state
    }

    public State GetTargetState()
    {
        return targetState;
    }
    public Action GetAction()
    {
        return action;
    }
}
