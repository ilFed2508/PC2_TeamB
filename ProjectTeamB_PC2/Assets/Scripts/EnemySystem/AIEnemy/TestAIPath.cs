using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAIPath : MonoBehaviour
{
    public Transform StartingDirectionPoint;
    public float PathLength;
    public float PathAngle;
    public Vector3[] PathPoints = new Vector3[3];
    public NavMeshAgent agent;
    public float Speed;
    public PlayerController player;
    public bool DrawPath;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        DrawPath = false;
        CalculatePath(PathPoints);
        //Debug.DrawLine(this.transform.position, PathPoints[0]);
        //Debug.DrawLine(PathPoints[0], PathPoints[1]);
        //Debug.DrawLine(PathPoints[1], PathPoints[2]);
        StartCoroutine(MoveCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //transform.position = Vector3.MoveTowards(this.transform.position, PathPoints[0], Speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if(DrawPath == true)
        {
            CalculatePath(PathPoints);

            Gizmos.DrawLine(this.transform.position, PathPoints[0]);
            Gizmos.DrawLine(PathPoints[0], PathPoints[1]);
            Gizmos.DrawLine(PathPoints[1], PathPoints[2]);
        }
    }

    public Vector3 CalculateFirstPoint(float vectorLength, float vectorAngle)
    {
        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        direction = Quaternion.AngleAxis(vectorAngle, Vector3.up) * direction;

        direction *= vectorLength;

        Vector3 finalvector3 = this.transform.position + direction;

        return finalvector3;
    }

    public Vector3 CalculateSecondPoint(float vectorlength, float vectorAngle)
    {
        Vector3 previouspoint = CalculateFirstPoint(PathLength, PathAngle);

        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        direction = Quaternion.AngleAxis(-vectorAngle, Vector3.up) * direction;

        direction *= (vectorlength * 2);

        Vector3 finalvector3 = previouspoint + direction;

        return finalvector3;
    }

    public Vector3 CalculateThirdPoint(float vectorlength, float vectorAngle)
    {
        Vector3 previouspoint = CalculateSecondPoint(PathLength, PathAngle);

        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        direction = Quaternion.AngleAxis(vectorAngle, Vector3.up) * direction;

        direction *= vectorlength;

        Vector3 finalvector3 = previouspoint + direction;

        return finalvector3;
    }

    public Vector3 CalculateFollowingPoint(float vectorlength, float vectorAngle, int ArrayIndex, Vector3[] PointsArray)
    {
        Vector3 previouspoint = PointsArray[ArrayIndex - 1];

        Vector3 direction = StartingDirectionPoint.position - this.transform.position;

        direction.Normalize();

        if(ArrayIndex % 2 == 1)
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

    public void CalculatePath(Vector3[] PathPoints)
    {
        PathPoints[0] = CalculateFirstPoint(PathLength, PathAngle);

        for (int i = 1; i < PathPoints.Length; i++)
        {
            PathPoints[i] = CalculateFollowingPoint(PathLength, PathAngle, i, PathPoints);
        }
    }

    public IEnumerator MoveCoroutine()
    {
        agent.SetDestination(PathPoints[0]);       
        yield return new WaitForSeconds(10f);

        agent.SetDestination(PathPoints[1]);
        yield return new WaitForSeconds(5f);

        agent.SetDestination(PathPoints[2]);
        yield return new WaitForSeconds(2f);
    }
}
