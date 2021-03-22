using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : State
{
    public float ShootingTimer;

    public ShootingState(EnemyBase enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {

    }

    public ShootingState(EnemyType1 enemyType1, StateMachine stateMachine) : base(enemyType1, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        ShootingTimer = 0f;

        enemyType1.Shoot();
    }

    public override void Exit()
    {
        base.Exit();

        enemyType1.StopShooting();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyType1.WatchPlayer();

        ShootingTimer += Time.deltaTime;

        if(ShootingTimer >= enemyType1.ShootingDuration)
        {
            stateMachine.ChangeState(enemyType1.zigZagMoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
