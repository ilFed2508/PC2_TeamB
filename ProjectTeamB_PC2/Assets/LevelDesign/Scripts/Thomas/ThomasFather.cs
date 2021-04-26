using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasFather : MonoBehaviour
{
    public GameObject[] rooms;

    private float spawnRoomLengh;
    private Vector3 spawnPos;
    private ThomasMovement speedUp;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        spawnRoomLengh = GetComponent<BoxCollider>().size.z;
        speedUp = GetComponent<ThomasMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= spawnPos.z + spawnRoomLengh)
        {
            int room = Random.Range(0, rooms.Length);
            spawnPos = transform.position;
            Instantiate(rooms[room], gameObject.transform.position, gameObject.transform.rotation);
            speedUp.speed += speedUp.increaseSpeed;
        }
    }
}
