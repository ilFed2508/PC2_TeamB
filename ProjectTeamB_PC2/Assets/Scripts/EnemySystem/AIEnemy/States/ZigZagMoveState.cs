using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMoveState : State
{
    public ZigZagMoveState(EnemyType1 enemyType1, StateMachine stateMachine) : base(enemyType1, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        enemyType1.agent.SetDestination(enemyType1.PathPoints[enemyType1.CurrentPathPosition]);
    }

    public override void Exit()
    {
        base.Exit();

        enemyType1.UpdateMyPathPosition();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemyType1.WatchPlayer();

        if(enemyType1.agent.remainingDistance <= enemyType1.agent.stoppingDistance)
        {
            stateMachine.ChangeState(enemyType1.shootingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
