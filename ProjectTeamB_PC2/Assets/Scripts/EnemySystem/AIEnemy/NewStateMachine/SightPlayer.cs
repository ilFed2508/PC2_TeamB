using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightPlayer : IState
{
    private EnemyBase _enemy;

    public SightPlayer(EnemyBase enemy)
    {
        _enemy = enemy;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        _enemy.WatchPlayer();
    }
}
