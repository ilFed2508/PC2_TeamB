using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase Enemy = other.gameObject.GetComponentInChildren<EnemyBase>();

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

    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
