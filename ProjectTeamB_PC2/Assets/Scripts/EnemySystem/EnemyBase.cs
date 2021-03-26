using System.Collections;
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
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon));
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
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon));
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
}
