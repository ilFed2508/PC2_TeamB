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

        if(EnableShooting() == true)
        {
            stateMachine.ChangeState(enemyType1.shootingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool EnableShooting()
    {
        float youAndPlayerDistance = Vector3.Distance(enemyType1.gameObject.transform.position, enemyType1.Player.gameObject.transform.position);

        if(Physics.Raycast(enemyType1.gameObject.transform.position, enemyType1.transform.forward, out RaycastHit hit, 200f))
        {
            Debug.DrawRay(enemyType1.transform.position, enemyType1.transform.forward * hit.distance, Color.blue);

            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        else
        {
            Debug.DrawRay(enemyType1.transform.position, enemyType1.transform.forward * 1000, Color.red);

        }

        return false;

    }
}
