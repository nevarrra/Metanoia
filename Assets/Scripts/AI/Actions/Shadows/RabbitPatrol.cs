using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Shadows/Rabbit Patrol")]
public class RabbitPatrol : Action
{
    public override void Act(FSM entity)
    {
        //entity.GetAgent().imaginaryFriend.InitialSearchTimer = entity.GetAgent().imaginaryFriend.SearchTimer;
        //entity.GetAgent().FUNCTION;
        entity.GetAgent().RabbitPatrol();
    }

    /*
     
    ░░░░░░░░░░░░░░▄▄▀▀██▀▄▄▒
░░░░░░░░░░░░▄▀░▄▀▀░░░▒▒▀▀▄
░░░░░░░░░░░▐░▄▀░░░░░░░░░░░█
░░░░░░░░░░░▌▌▒▒▒▒░░░░░░░░░░█
░░░░░░▄▄▄░▐▒▒▒▒▒▒░░▒▄▄▄▄░▄░░▌
░░░░▄▀░▄░▐▐▒▒▒▒▒░░░▀░░░░▀░▄▀▐
░░░█░▌░░▌░▐▐▀▄▒▒░░░▒▌██▐░░▌▄▐
░░▐░▐░░░▐░▌▐▐░▒░░░░░░▀▀░░░░░▀▌
░░▌░▌░░░░▌▐▄▀░▒▒▒░░░░░░░▄▀▄░░▐
░▐▐░▌░░░░▐▐░▌▒▒▒▒▒▒▒▒▒▒█▄▄▄░░░▌
░▌░░▌▌░░░░▌░▐▒▒▒▒▒▒▄▄▄▄▄▄▄▄▀▄▄▀
░▐░░▌▌░░░░▐░░▌▒▒▒▒▒▄▀█▄▄▄▄▀
░▌▌░▌▌░░░░░▌░▐▒▒▒▒▒▒▀▄▀▀▀▄
▐░░░▐▐░░░░░▐▐░▌▒▒▒▒▒▒▒▀▀░▄▀█
▌▌░░░▌▌░░░░░█▐░▌▒▒▒▒▒▒▒▄▀░▄▐▄▄
▌░░░░▐▐░░░░░░▀░▐▒▒▒▒▒▄▀░░░▀▀▄▀▌
░░░░░░▌░░░░░▄▀█▄█▄▀▀░▀▄░░░░▀░▀▐
░░░░░░▐░░░░░░░▌░░░░░░▐▐░▀▄▀▄▀▄▀
░░░░░░░█░░░░░▐░░░▌░░░█▀▀▄▀▄▀▄▀
░░░░░░░░▀▄░░▄▄▄▀▐▄▄▀▀
░░░░░░░░░░▀▄▄▄▄▄▀

     */

}

