﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunShootingType : Shooting
{
    /// <summary>
    /// number of shots in a sigle pallet
    /// </summary>
    public int PalletShotNumber;
    /// <summary>
    /// percentage of bloom you desire on the shot
    /// </summary>
    public float Bloom;


    // Shake Luca
    public CameraShake.Properties testProperties;
    public Animator Pompa;
    public GameObject Flash;
    public Transform Parent;
    public string Suono;
    private DroneShake MyLevelZero;
    private ComboManager MyComboZero;



    private void Start()
    {
        //Luca Animazione Pompa
        Pompa.GetComponent<Animator>();

        MyLevelZero = GameObject.Find("Combo Level").GetComponent<DroneShake>();
        MyComboZero = FindObjectOfType<ComboManager>();
    }

    public override void ShootingAction(RangedWeapon currentWeapon)
    {
        if (CanWeaponShoot == true && currentWeapon.CurrentAmmo > 0)
        {
            Shoot(currentWeapon);
            currentWeapon.CurrentAmmo -= 1;
            StartCoroutine(WaitShotCooldown(ShotCooldown));
            if (currentWeapon.CurrentAmmo == 0)
            {
                AudioManager.instance.Play("ZeroFeed");
                MyLevelZero.enabled = true;
                MyLevelZero.gameObject.GetComponent<Text>().color = Color.red;
                StartCoroutine(lateCall());
                MyComboZero.ZeroVFX.SetActive(true);
            }
        }
    }

    public override void Shoot(RangedWeapon currentWeapon)
    {
        //Luca Animazione Pompa
        Pompa.Play("PompaShoot");

        for (int palletsShot = 0; palletsShot < PalletShotNumber; palletsShot++)
        {
            
            Vector2 randomBloom = new Vector2(GetRandomBloomValue(Bloom), GetRandomBloomValue(Bloom));

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(randomBloom.x, randomBloom.y, 1f));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                ShootingTargetPoint = hit.point;
            }
            else
            {
                ShootingTargetPoint = ray.GetPoint(80);
            }

            Vector3 ShootingDirection = ShootingTargetPoint - currentWeapon.GunBarrel.position;

            AudioManager.instance.Play(Suono);
            GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab, currentWeapon.GunBarrel.position, Quaternion.identity);

            BulletInstance.transform.forward = ShootingDirection.normalized;

            BulletInstance.GetComponent<Rigidbody>().AddForce(ShootingDirection.normalized * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);

            //Shake Luca
            FindObjectOfType<CameraShake>().StartShake(testProperties);
            //Luca
            Instantiate(Flash, Parent);
        }        
    }

    /// <summary>
    /// calculate and return a random bloom value based on a percentage
    /// </summary>
    /// <param name="BloomPercentage"></param>
    /// <returns></returns>
    public float GetRandomBloomValue(float BloomPercentage)
    {
        float bloomPercentageValue = (0.5f / 100) * BloomPercentage;
        float randomBloomPercentage = Random.Range(0f, bloomPercentageValue);

        float randomBloom;
        
        int sign = Random.Range(0, 2);
        if(sign == 0)
        {
            randomBloom = 0.5f - randomBloomPercentage;
        }
        else
        {
            randomBloom = 0.5f + randomBloomPercentage;
        }

        return randomBloom;
    }

    public override float CalculateFireRateo()
    {
        float firerateo = 60 / ShotCooldown;

        return firerateo;
    }

    public override float CalculateTotalDamage(RangedWeapon CurrentWeapon)
    {
        float totalDamage = CurrentWeapon.weaponData.Damage * PalletShotNumber;

        return totalDamage;
    }

    IEnumerator lateCall()
    {
        yield return new WaitForSeconds(MyLevelZero.shakeDuration);
        MyLevelZero.gameObject.GetComponent<Text>().color = Color.white;
    }
}
