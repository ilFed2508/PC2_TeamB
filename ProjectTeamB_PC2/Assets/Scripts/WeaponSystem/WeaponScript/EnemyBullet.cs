using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [HideInInspector]
    public float Damage;
   
    // Start is called before the first frame update
    void Start()
    {        
        Destroy(this.gameObject, 3f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            other.GetComponent<PlayerController>().playerLife.DamagePlayer(Damage);
            other.GetComponent<ActivePanel>().StartCoroutine("FadeInAndOut");
            Destroy(this.gameObject);
            Debug.Log("Colpisco");
        }

        if (other.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }
    }
}
