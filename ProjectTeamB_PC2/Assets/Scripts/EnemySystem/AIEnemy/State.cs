using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State
{
    protected EnemyBase enemy;
    protected EnemyType1 enemyType1;
    protected StateMachine stateMachine;

    protected State(EnemyBase enemy, StateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }

    protected State(EnemyType1 enemytype1, StateMachine stateMachine)
    {
        this.enemyType1 = enemytype1;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}

