﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn1, spawn2;

    private DetectedActDeact hudOn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            Vector3 position1 = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
            Instantiate(player, position1, spawn2.transform.rotation);
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 2)
        {
            Vector3 position2 = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z);
            Instantiate(player, position2, spawn2.transform.rotation);
            hudOn = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
            hudOn.thing.SetActive(true);
        }
    }
}
