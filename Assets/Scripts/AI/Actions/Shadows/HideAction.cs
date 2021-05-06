using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Hide")]
public class HideAction : Action
{
    public override void Act(FSM entity)
    {
       
            if(!entity.GetAgent().IsPathStalled())
            {
                entity.GetAgent().SetDestinationTo(entity.GetAgent().GetClosestWaypoint(entity.GetAgent().GetClosestCorner().transform.position).transform.position);
            }
            //create entry action to calc closest corner and wp to it and set destinationTo
            //in this action nothing is needed
            // OR can use if path pending condition here to only calc once...
            
        
        
    }
}
