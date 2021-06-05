using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalON : MonoBehaviour
{
    public GameObject Directional;
    public GameObject DirectionalTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Directional.SetActive(true);
            Destroy(DirectionalTrigger);
        }
    }
}