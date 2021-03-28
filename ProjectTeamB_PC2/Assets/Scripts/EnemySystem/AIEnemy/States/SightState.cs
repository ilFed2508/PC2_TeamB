using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightState : State
{
    public SightState(EnemyBase enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public SightState(EnemyType1 enemyType1, StateMachine stateMachine) : base(enemyType1, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyType1.WatchPlayer();

        if(enemyType1.EnableShooting() == true)
        {
            stateMachine.ChangeState(enemyType1.shootingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}
