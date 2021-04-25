using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject Particle;

    private PlayerController Playercontroller;

    // Update is called once per frame
    void Start()
    {
        Playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Destroy(this.gameObject, 3f);
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Playercontroller.HitMarker.SetActive(true);
            //Instantiate(Particle, spawnPos, gameObject.transform.rotation);
            EnemyBase Enemy = other.gameObject.GetComponentInChildren<EnemyBase>();

            Enemy.DamageEnemy();

            if(Enemy.HP <= 0)
            {
                Instantiate(Particle, spawnPos, gameObject.transform.rotation);
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                Destroy(other.gameObject);
                Playercontroller.HitMarkerKill.SetActive(true);
                Playercontroller.PanelKill.SetActive(true);
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
