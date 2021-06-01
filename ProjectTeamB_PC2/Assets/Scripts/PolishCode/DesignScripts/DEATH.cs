using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATH : MonoBehaviour
{
    private PlayerLifeSystem hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hp.PlayerCurrentHP = 0;
    }
}
