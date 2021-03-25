using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseBehaviour : MonoBehaviour
{
    public PlayerController Player;
    public float BonusLifeWhenKilled;
    public float HP;
    public RangedWeapon MyWeapon;

    //image feed enemies in shooting - Joe
    public Image Attention;
    public Image RedEye;

    //enemy life bar - Joe
    public Slider EnemyLifeBar;
    public float CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();

        StartCoroutine(ShootCoroutine());
        StartCoroutine(ImageFeed());
    }

    // Update is called once per frame
    void Update()
    {
        WatchPlayer();

        //enemy life bar - Joe
        EnemyLifeBar.value = HP;
    }

    //image feed enemies in shooting - Joe
    public IEnumerator ImageFeed()
    {
        RedEye.enabled = false;
        Attention.enabled = true;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = true;
        Attention.enabled = false;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = false;
        Attention.enabled = true;
        yield return new WaitForSeconds(1f);
        RedEye.enabled = true;
        Attention.enabled = false;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = false;
        Attention.enabled = true;
        yield return new WaitForSeconds(1f);
        RedEye.enabled = true;
        Attention.enabled = false;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = false;
        Attention.enabled = true;
        yield return new WaitForSeconds(1f);
        RedEye.enabled = true;
        Attention.enabled = false;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = false;
        Attention.enabled = true;
        yield return new WaitForSeconds(1f);
        RedEye.enabled = true;
        Attention.enabled = false;
        yield return new WaitForSeconds(2f);
        RedEye.enabled = false;
        Attention.enabled = true;
    }

    public void WatchPlayer()
    {
        transform.LookAt(Player.gameObject.transform);
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

        if(Player.playerLife.PlayerCurrentHP > Player.playerLife.PlayerStartingHP)
        {
            Player.playerLife.PlayerCurrentHP = Player.playerLife.PlayerStartingHP;
        }
    }

    public void DamageEnemy()
    {
        HP -= Player.playerShooting.CurrentRagedWeapon.weaponData.Damage;
    }

    //Melee Luca
    public void DamageMelee()
    {
        HP -= HP;
    }



}
