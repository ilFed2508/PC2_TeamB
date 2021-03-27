﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Base Enemy Fields")]
    public PlayerController Player;
    public float BonusLifeWhenKilled;
    public float HP;
    public RangedWeapon MyWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //picking reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        //shoot
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon, this));
    }

    // Update is called once per frame
    void Update()
    {
        WatchPlayer();
    }
        
    /// <summary>
    /// keep Watching the player
    /// </summary>
    public void WatchPlayer()
    {
        transform.LookAt(Player.gameObject.transform);
    }

    /// <summary>
    /// Shooting coroutine based on the AIshooting methods
    /// </summary>
    public void Shoot()
    {
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon, this));
    }

    /// <summary>
    /// Stop shooting coroutines
    /// </summary>
    public void StopShooting()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Healing player method when the enemy die
    /// </summary>
    public void PlayerHealOnDeath()
    {
        Player.playerLife.PlayerCurrentHP += BonusLifeWhenKilled;

        if (Player.playerLife.PlayerCurrentHP > Player.playerLife.PlayerStartingHP)
        {
            Player.playerLife.PlayerCurrentHP = Player.playerLife.PlayerStartingHP;
        }
    }

    /// <summary>
    /// Damage enemy method
    /// </summary>
    public void DamageEnemy()
    {
        HP -= Player.playerShooting.CurrentRagedWeapon.weaponData.Damage;
    }

    /// <summary>
    /// return true if the player is on sight and enable shooting
    /// </summary>
    /// <returns></returns>
    public bool EnableShooting()
    {
        float youAndPlayerDistance = Vector3.Distance(this.gameObject.transform.position, transform.forward);

        if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out RaycastHit hit, 500f))
        {
            //Debug.DrawRay(enemyType1.transform.position, enemyType1.transform.forward * hit.distance, Color.blue);

            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;

    }
}
