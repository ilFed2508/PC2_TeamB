using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFist : MonoBehaviour
{
    public ParticleSystem Particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Particle, spawnPos, other.transform.rotation);

            EnemyBase Enemy = other.gameObject.GetComponentInChildren<EnemyBase>();

            Enemy.DamageMelee();

            if (Enemy.HP <= 0)
            {
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                Destroy(other.gameObject);
            }

            
        }
      
    }
}
