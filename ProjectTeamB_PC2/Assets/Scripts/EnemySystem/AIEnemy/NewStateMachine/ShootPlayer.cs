using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : IState
{
    private EnemyType1 _enemyType1;

    public ShootPlayer(EnemyType1 enemy)
    {
        _enemyType1 = enemy;
    }

    public void OnEnter()
    {
        _enemyType1.ShootingTimer = 0f;
        _enemyType1.Shoot();
    }

    public void Tick()
    {
        _enemyType1.WatchPlayer();
        _enemyType1.ShootingTimer += Time.deltaTime;
    }

    public void OnExit()
    {
        _enemyType1.ShootingTimer = 0f;
        _enemyType1.StopShooting();
    }


}
