using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyType2 : EnemyBase
{
    //state machine variables
    private StateMachine _stateMachine;

    public NavMeshAgent agent;

    public float PlayerStopDistance;

    

    private void Awake()
    {
        //pick reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        //SetupEnemyType
        enemyType = EnemyType.typeC;

        MyFeed = FindObjectOfType<MedikitManager>();

        //state machine setup
        _stateMachine = new StateMachine();
        var Sight = new SightPlayer(this);
        var followAndshoot = new FollowAndShoot(this);

        //add transition between state
        AddTransition(Sight, followAndshoot, SpottedPlayer());

        //set conidtions
        Func<bool> SpottedPlayer() => () => EnableShooting();
        //Func<bool> ReachedStoppingPoint() => () => agent.remainingDistance <= agent.stoppingDistance;

        _stateMachine.SetState(Sight);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    public void FollowPlayer()
    {
        //Vector3 playerDestinantion = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);

        Vector3 playerDestinantion = Player.transform.position;
        agent.SetDestination(playerDestinantion);
    }

    public void StopFollowing()
    {
        agent.SetDestination(this.transform.position);
    }

    public void UpdateFollow()
    {
        Debug.Log(Vector3.Distance(this.transform.position, Player.transform.position));

        if(Vector3.Distance(this.transform.position, Player.transform.position) > PlayerStopDistance)
        {
            FollowPlayer();
        } 
        else if(Vector3.Distance(this.transform.position, Player.transform.position) <= PlayerStopDistance)
        {
            StopFollowing();
        }
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate) => _stateMachine.AddTransition(from, to, predicate);
}
