using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour
{
    public bool hitOn = false;

    private void Start()
    {

    }

    private void Update()
    {   
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Enemy"))
       {
            hitOn = true;
            Destroy(gameObject);
       }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }

    IEnumerator Hitten()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        hitOn = false;
    }

}






