using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFist : MonoBehaviour
{
    public ParticleSystem Particle;
    public string HitKill;

    private HitmarkerFather playerC;
    public string Hit;



    private void Start()
    {
        playerC = GameObject.Find("HitContainer").GetComponent<HitmarkerFather>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Particle, spawnPos, other.transform.rotation);
            playerC.hit.SetActive(true);
            EnemyBase Enemy = other.gameObject.GetComponentInChildren<EnemyBase>();

            Enemy.DamageMelee();
            AudioManager.instance.Play(Hit);

            if (Enemy.HP <= 0)
            {
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                AudioManager.instance.Play(HitKill);
                playerC.hitDeath.SetActive(true);
                playerC.hitPanel.SetActive(true);
                Destroy(other.gameObject);
            }

            
        }
      
    }
}
