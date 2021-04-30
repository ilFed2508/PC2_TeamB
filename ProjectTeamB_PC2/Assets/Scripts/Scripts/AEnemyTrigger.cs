using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEnemyTrigger : MonoBehaviour
{
    public GameObject enemies;

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
        if (other.CompareTag("Player"))
        {
            enemies.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemies.SetActive(false);
        }
    }
}
