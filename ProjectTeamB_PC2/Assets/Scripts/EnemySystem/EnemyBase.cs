using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public PlayerController Player;
    public float BonusLifeWhenKilled;
    public float HP;
    public RangedWeapon MyWeapon;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon));
    }

    // Update is called once per frame
    void Update()
    {
        WatchPlayer();
    }

    public void WatchPlayer()
    {
        transform.LookAt(Player.gameObject.transform);
    }

    public void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }

    public void StopShooting()
    {
        StopAllCoroutines();
    }

    public IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(MyWeapon.ShootingType.ShotCooldown);
            EnemyShooting();
        }

    }

    public void EnemyShooting()
    {
        GameObject BulletInstance = Instantiate(MyWeapon.WeaponBulletPrefab, MyWeapon.GunBarrel.position, Quaternion.identity);
        BulletInstance.GetComponent<EnemyBullet>().Damage = MyWeapon.weaponData.Damage;
        BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * MyWeapon.weaponData.ShootingForce, ForceMode.Impulse);
    }

    public void PlayerHealOnDeath()
    {
        Player.playerLife.PlayerCurrentHP += BonusLifeWhenKilled;

        if (Player.playerLife.PlayerCurrentHP > Player.playerLife.PlayerStartingHP)
        {
            Player.playerLife.PlayerCurrentHP = Player.playerLife.PlayerStartingHP;
        }
    }

    public void DamageEnemy()
    {
        HP -= Player.playerShooting.CurrentRagedWeapon.weaponData.Damage;
    }
}
