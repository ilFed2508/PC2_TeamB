using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndShoot : IState
{
    private EnemyType2 _enemyType2;

    public FollowAndShoot(EnemyType2 enemy)
    {
        _enemyType2 = enemy;
    }

    public void OnEnter()
    {
        _enemyType2.Shoot();
    }

    public void Tick()
    {        
        _enemyType2.WatchPlayer();

        _enemyType2.UpdateFollow();
    }

    public void OnExit()
    {
        
    }


}
