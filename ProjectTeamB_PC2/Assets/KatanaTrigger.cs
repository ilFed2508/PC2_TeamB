using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaTrigger : MonoBehaviour
{
    public ParticleSystem Particle;
    public string HitKill;

    private HitmarkerFather playerC;
    public string Hit,VoidHit,WallHit;

    public float KatanaD;


    private PlayerController MyPlayer;




    private void Start()
    {
        MyPlayer = FindObjectOfType<PlayerController>();
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

            Enemy.KatanaDamage(KatanaD);
            AudioManager.instance.Play(Hit);

            if (Enemy.HP <= 0)
            {
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                if ((int)Enemy.enemyType == 1)
                {
                    Enemy.Player.playerScore.AddScore(2);
                }
                if ((int)Enemy.enemyType == 2)
                {
                    Enemy.Player.playerScore.AddScore(3);
                }
                if ((int)Enemy.enemyType == 3)
                {
                    Enemy.Player.playerScore.AddScore(4);
                }
                AudioManager.instance.Play(HitKill);
                playerC.hitDeath.SetActive(true);
                playerC.hitPanel.SetActive(true);
                Destroy(other.gameObject);
            }


        }

    }
}
