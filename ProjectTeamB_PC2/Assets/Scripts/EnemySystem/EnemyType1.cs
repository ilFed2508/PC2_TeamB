using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : EnemyBase
{
    public SightState sightState;
    public ShootingState shootingState;
    public ZigZagMoveState zigZagMoveState;
    public StateMachine EnemyStateMachine;


    public float ShootingDuration;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        EnemyStateMachine = new StateMachine();

        sightState = new SightState(this, EnemyStateMachine);
        shootingState = new ShootingState(this, EnemyStateMachine);
        zigZagMoveState = new ZigZagMoveState(this, EnemyStateMachine);

        EnemyStateMachine.Initialize(sightState);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyStateMachine.CurrentState.HandleInput();

        EnemyStateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.CurrentState.PhysicsUpdate();
    }
}
