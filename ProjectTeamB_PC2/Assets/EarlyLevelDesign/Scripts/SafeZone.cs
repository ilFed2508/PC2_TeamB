using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameObject mapIn, mapOut;
    public int playerPrefs;

    public PlayerLifeSystem playerLife;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerLife.PlayerCurrentHP < playerLife.PlayerStartingHP)
        {
            //playerLife.PlayerCurrentHP = playerLife.PlayerStartingHP;
            playerLife.PlayerCurrentHP += 5 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mapIn.SetActive(false);
            mapOut.SetActive(true);
            PlayerPrefs.SetInt("Checkpoint", playerPrefs);
        }
    }
}
