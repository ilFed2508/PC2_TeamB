using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Elevator, Player;
    public Transform On, Off;
    public float speed;

    private bool isActivate;

     void Update()
    {
        if (isActivate == true)
        {
            Elevator.transform.position = Vector3.Lerp(Elevator.transform.position, On.position, Time.deltaTime * speed);
        }
        else
            Elevator.transform.position = Vector3.Lerp(Elevator.transform.position, Off.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isActivate = false;
        }
    }
}
