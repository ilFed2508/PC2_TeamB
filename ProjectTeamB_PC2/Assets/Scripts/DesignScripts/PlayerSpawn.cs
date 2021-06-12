using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject playerDisarmato;
    public GameObject playerGOD;
    public GameObject playerDisarmatoGOD;
    public GameObject spawn1, spawn2, spawn3, spawn4;

    private DetectedActDeact hudOn;


    // Start is called before the first frame update
    void Start()
    {

        //if (PlayerPrefs.HasKey("GodmodeActivated") == false)
        //{
        //    PlayerPrefs.SetInt("GodmodeActivated", 0);
        //    PlayerPrefs.Save();
        //}

        Spawn();
    }



    private void Spawn()
    {
        if (PlayerPrefs.GetInt("Checkpoint") == 1)
        {
            Vector3 position1 = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
            GameObject PlayerSpawned;
            if (PlayerPrefs.GetInt("GodmodeActivated") == 1)
            {
                //godmodeAttiva
                PlayerSpawned = Instantiate(playerDisarmatoGOD, position1, spawn1.transform.rotation);
            }
            else
            {
                //GodmodeDisattiva
                PlayerSpawned = Instantiate(playerDisarmato, position1, spawn1.transform.rotation);
            }           
            //reset score
            ScoreController scoreController = PlayerSpawned.GetComponent<ScoreController>();
            if(PlayerPrefs.GetInt("PlayerTotalScore") != 0)
            {
                PlayerPrefs.SetInt("PlayerTotalScore", 0);
                PlayerPrefs.Save();                
            }
            scoreController.SetTotalScore(PlayerPrefs.GetInt("PlayerTotalScore"));

        }

        if (PlayerPrefs.GetInt("Checkpoint") == 2)
        {
            Vector3 position2 = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z);
            GameObject PlayerSpawned;
            if (PlayerPrefs.GetInt("GodmodeActivated") == 1)
            {
                //godmodeAttiva
                PlayerSpawned = Instantiate(playerGOD, position2, spawn2.transform.rotation);
            }
            else
            {
                //GodmodeDisattiva
                PlayerSpawned = Instantiate(player, position2, spawn2.transform.rotation);
            }
            hudOn = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
            hudOn.thing.SetActive(true);
            //set new totalscore
            PlayerSpawned.GetComponent<ScoreController>().SetTotalScore(PlayerPrefs.GetInt("PlayerTotalScore"));
            
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 3)
        {
            Vector3 position2 = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, spawn3.transform.position.z);
            
            GameObject PlayerSpawned;
            if (PlayerPrefs.GetInt("GodmodeActivated") == 1)
            {
                //godmodeAttiva
                PlayerSpawned = Instantiate(playerGOD, position2, spawn3.transform.rotation);
            }
            else
            {
                //GodmodeDisattiva
                PlayerSpawned = Instantiate(player, position2, spawn3.transform.rotation);
            }
            hudOn = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
            hudOn.thing.SetActive(true);
            //set new totalscore
            PlayerSpawned.GetComponent<ScoreController>().SetTotalScore(PlayerPrefs.GetInt("PlayerTotalScore"));
            
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 4)
        {
            Vector3 position2 = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, spawn4.transform.position.z);
            GameObject PlayerSpawned;
            if (PlayerPrefs.GetInt("GodmodeActivated") == 1)
            {
                //godmodeAttiva
                PlayerSpawned = Instantiate(playerGOD, position2, spawn4.transform.rotation);
            }
            else
            {
                //GodmodeDisattiva
                PlayerSpawned = Instantiate(player, position2, spawn4.transform.rotation);
            }
            hudOn = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
            hudOn.thing.SetActive(true);
            //set new totalscore
            PlayerSpawned.GetComponent<ScoreController>().SetTotalScore(PlayerPrefs.GetInt("PlayerTotalScore"));
            
        }
    }
}
