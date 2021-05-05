using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasMovement : MonoBehaviour
{
    public float speed, increaseSpeed;
    public Transform room;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        room.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
