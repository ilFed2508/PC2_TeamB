using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject Particle;

    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    //Prova con OnCollision Design
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Particle, spawnPos, gameObject.transform.rotation);

            EnemyBaseBehaviour Enemy = collision.gameObject.GetComponentInChildren<EnemyBaseBehaviour>();

            Enemy.DamageEnemy();

            if(Enemy.HP <= 0)
            {
                collision.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }
        

    }
    //-----------------------------------------------------


    /*
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Particle, spawnPos, gameObject.transform.rotation);

            EnemyBaseBehaviour Enemy = other.gameObject.GetComponentInChildren<EnemyBaseBehaviour>();

            Enemy.DamageEnemy();

            if(Enemy.HP <= 0)
            {
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);
        }

        if (other.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }

    }*/
}
