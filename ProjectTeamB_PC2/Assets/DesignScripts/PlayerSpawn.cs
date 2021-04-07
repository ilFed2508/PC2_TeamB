using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn1, spawn2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            Vector3 position1 = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
            Instantiate(player, position1, Quaternion.identity);

            //player.transform.position = spawn1.transform.position;
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 2)
        {
            Vector3 position2 = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z);
            Instantiate(player, position2, Quaternion.identity);

            //player.transform.position = spawn2.transform.position;
        }
    }
}
