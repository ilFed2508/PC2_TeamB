using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyType1 : EnemyBase
{
    //state machine variables
    public SightState sightState;
    public ShootingState shootingState;
    public ZigZagMoveState zigZagMoveState;
    public StateMachine EnemyStateMachine;

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

    // Start is called before the first frame update
    void Start()
    {
        //pick reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        //setup and path calculation
        DrawPath = false;
        CurrentPathPosition = 0;
        counterUP = true;
        CalculatePath(PathPoints);

        //creating states and itialize the state machine
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
}
