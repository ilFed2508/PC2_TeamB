using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyType1 : EnemyBase
{
    //state machine variables
    private StateMachine _stateMachine;

    [Header("Ai Path Manipulation")]
    public float PathLength;
    public float PathAngle;
    public bool DrawPath;
    [HideInInspector]
    public Vector3[] PathPoints = new Vector3[3];
    public NavMeshAgent agent;    
    public Transform StartingDirectionPoint;
    [HideInInspector]
    public int CurrentPathPosition;
    [HideInInspector]
    public bool counterUP;

    [Header("Shooting State Timer")]
    public float ShootingDuration;
    [HideInInspector]
    public float ShootingTimer;

    private void Awake()
    {
        //pick reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();
        StartCoroutine("floating");

        //SetupEnemyType
        enemyType = EnemyType.typeB;
        MyFeed = FindObjectOfType<MedikitManager>();

        //state machine setup
        _stateMachine = new StateMachine();
        var Sight = new SightPlayer(this);
        var Shoot = new ShootPlayer(this);
        var ZigZag = new ZigZagMovement(this);

        //add transition between state
        AddTransition(Sight, ZigZag, SpottedPlayer());
        AddTransition(Shoot, ZigZag, HasShooted());
        AddTransition(ZigZag, Shoot, ReachedNextPoint());

        //set conidtions
        Func<bool> SpottedPlayer() => () => EnableShooting();
        Func<bool> HasShooted() => () => ShootingTimer >= ShootingDuration;
        Func<bool> ReachedNextPoint() => () => agent.remainingDistance <= agent.stoppingDistance;

        _stateMachine.SetState(Sight);
    }

    // Start is called before the first frame update
    void Start()
    {
        //setup and path calculation
        DrawPath = false;
        CurrentPathPosition = 0;
        counterUP = true;
        CalculatePath(PathPoints);
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    public void OnDrawGizmos()
    {
        //path drawing
        if (DrawPath == true)
        {
            CalculatePath(PathPoints);

            Gizmos.DrawLine(this.transform.position, PathPoints[0]);
            Gizmos.DrawLine(PathPoints[0], PathPoints[1]);
            Gizmos.DrawLine(PathPoints[1], PathPoints[2]);
        }
    }

    /// <summary>
    /// calculate the first point of the path
    /// </summary>
    /// <param name="vectorLength"></param>
    /// <param name="vectorAngle"></param>
    /// <returns></returns>
    public Vector3 CalculateFirstPoint(float vectorLength, float vectorAngle)
    {
        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        direction = Quaternion.AngleAxis(vectorAngle, Vector3.up) * direction;

        direction *= vectorLength;

        Vector3 finalvector3 = this.transform.position + direction;

        return finalvector3;
    }

    /// <summary>
    /// calculate the following point after the first one
    /// </summary>
    /// <param name="vectorlength"></param>
    /// <param name="vectorAngle"></param>
    /// <param name="ArrayIndex"></param>
    /// <param name="PointsArray"></param>
    /// <returns></returns>
    public Vector3 CalculateFollowingPoint(float vectorlength, float vectorAngle, int ArrayIndex, Vector3[] PointsArray)
    {
        Vector3 previouspoint = PointsArray[ArrayIndex - 1];

        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        if (ArrayIndex % 2 == 1)
        {
            direction = Quaternion.AngleAxis(-vectorAngle, Vector3.up) * direction;
            direction *= (vectorlength * 2);
        }
        else
        {
            direction = Quaternion.AngleAxis(vectorAngle, Vector3.up) * direction;
            direction *= (vectorlength);
        }



        Vector3 finalvector3 = previouspoint + direction;

        return finalvector3;

    }

    /// <summary>
    /// calculate all the path point and put the in the pathpoint array
    /// </summary>
    /// <param name="PathPoints"></param>
    public void CalculatePath(Vector3[] PathPoints)
    {
        PathPoints[0] = CalculateFirstPoint(PathLength, PathAngle);

        for (int i = 1; i < PathPoints.Length; i++)
        {
            PathPoints[i] = CalculateFollowingPoint(PathLength, PathAngle, i, PathPoints);
        }
    }

    /// <summary>
    /// update your path position counter
    /// </summary>
    public void UpdateMyPathPosition()
    {
        if(CurrentPathPosition == 0)
        {
            counterUP = true;
        }
        else if(CurrentPathPosition == 2)
        {
            counterUP = false;
        }


        if(counterUP == true)
        {
            CurrentPathPosition++;
        }
        else
        {
            CurrentPathPosition--;
        }
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate) => _stateMachine.AddTransition(from, to, predicate);
}
