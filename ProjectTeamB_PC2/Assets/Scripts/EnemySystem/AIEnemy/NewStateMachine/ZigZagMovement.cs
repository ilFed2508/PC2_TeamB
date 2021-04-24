using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : IState
{
    private EnemyType1 _enemyType1;

    public ZigZagMovement(EnemyType1 enemy)
    {
        _enemyType1 = enemy;
    }

    public void OnEnter()
    {
        _enemyType1.agent.SetDestination(_enemyType1.PathPoints[_enemyType1.CurrentPathPosition]);
    }

    public void Tick()
    {
        _enemyType1.WatchPlayer();
    }

    public void OnExit()
    {
        _enemyType1.UpdateMyPathPosition();
    }


}
