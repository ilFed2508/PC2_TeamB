using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAreaSingle : MonoBehaviour
{
    [Header("Maps")]
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    [Header("After Exit")]
    public GameObject doors1;
    public GameObject doors2;
    public GameObject doors3;
    [Header("Checkpoints")]
    public int checkpoint1;
    public int checkpoint2;
    [Header("Other Things")]
    public float recoverdLife;
    public int checkpoint;

    private PlayerLifeSystem playerLife;

    public void Start()
    {
        playerLife = FindObjectOfType<PlayerLifeSystem>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerLife.PlayerCurrentHP < playerLife.PlayerStartingHP)
        {
            playerLife.PlayerCurrentHP += recoverdLife * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(PlayerPrefs.GetInt("Checkpoint") == 1 && other.tag == "Player")
        {
            CheckIn1();
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 2 && other.tag == "Player")
        {
            CheckIn2();
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 3 && other.tag == "Player")
        {
            CheckIn3();
        }
    }

    void CheckIn1()
    {
        map2.SetActive(true);
    }

    void CheckIn2()
    {
        map3.SetActive(true);
    }

    void CheckIn3()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerPrefs.GetInt("Checkpoint") == 1 && other.tag == "Player")
        {
            CheckOut1();
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 2 && other.tag == "Player")
        {
            CheckOut2();
        }

        if (PlayerPrefs.GetInt("Checkpoint") == 3 && other.tag == "Player")
        {
            CheckOut3();
        }
    }

    void CheckOut1()
    {
        doors2.SetActive(true);
        map1.SetActive(false);
        PlayerPrefs.SetInt("Checkpoint", checkpoint1);
    }

    void CheckOut2()
    {
        doors3.SetActive(true);
        map3.SetActive(false);
        PlayerPrefs.SetInt("Checkpoint", checkpoint2);
    }

    void CheckOut3()
    {

    }
}
