using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BurstShootingType : Shooting
{
    /// <summary>
    /// Number of shots in single burst
    /// </summary>
    public int SingleBurstShotNumber;
    /// <summary>
    /// Cooldown timer between bursts fire
    /// </summary>
    public float CooldownBetweenBursts;

    //Shake Luca
    public CameraShake.Properties testProperties;
    public GameObject Flash;
    public Transform Parent;
    public string Suono;

    //Da eliminare più avanti
    private Animator anim;

    //FeedDelCristoDiCuiNonCiSarebbeBisognoSeLaGenteSapesseFareIlProprioLavoro
    public GameObject feedAnime;

    private void Start()
    {
        StartCoroutine("PORCODIO");
        //Da eliminare più avanti
        anim = GetComponent<Animator>();
    }

    public override void ShootingAction(RangedWeapon currentWeapon)
    {
        if(CanWeaponShoot == true && currentWeapon.CurrentAmmo > 0)
        {
            StartCoroutine(ShootBurst(ShotCooldown, currentWeapon));
            StartCoroutine(WaitShotCooldown(CooldownBetweenBursts));
        }       
    }

    public override void Shoot(RangedWeapon currentWeapon)
    {   
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1f));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ShootingTargetPoint = hit.point;
        }
        else
        {
            ShootingTargetPoint = ray.GetPoint(80);
        }

        Vector3 ShootingDirection = ShootingTargetPoint - currentWeapon.GunBarrel.position;

        GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab, currentWeapon.GunBarrel.position, Quaternion.identity);

        BulletInstance.transform.forward = ShootingDirection.normalized;

        anim.SetBool("Sparo",true);

        BulletInstance.GetComponent<Rigidbody>().AddForce(ShootingDirection.normalized * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);

        //Audio Luca
        AudioManager.instance.Play(Suono);

        //Shake Luca
        FindObjectOfType<CameraShake>().StartShake(testProperties);
        
    }

    public override void AIShoot(RangedWeapon currentWeapon)
    {
        GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab, currentWeapon.GunBarrel.position, Quaternion.identity);
        BulletInstance.GetComponent<EnemyBullet>().Damage = currentWeapon.weaponData.Damage;
        BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);
    }

    /// <summary>
    /// coroutine that shoot a burst and wait the shot cooldown between them
    /// </summary>
    /// <param name="shotCooldown"></param>
    /// <param name="currentWeapon"></param>
    /// <returns></returns>
    public IEnumerator ShootBurst(float shotCooldown, RangedWeapon currentWeapon)
    {
        if (SingleBurstShotNumber >= 2)
        {
            for (int shots = 0; shots < SingleBurstShotNumber; shots++)
            {
                Shoot(currentWeapon);
                //Luca
                Instantiate(Flash, Parent);
                currentWeapon.CurrentAmmo -= 1;
                yield return new WaitForSeconds(shotCooldown);
            }
        }

    }

    public IEnumerator AIShotBurst(float shotCooldown, RangedWeapon currentWeapon)
    {
        if (SingleBurstShotNumber >= 2)
        {
            for (int shots = 0; shots < SingleBurstShotNumber; shots++)
            {
                AIShoot(currentWeapon);
                yield return new WaitForSeconds(shotCooldown);
            }
        }
    }

    public override IEnumerator AIShootCoroutine(RangedWeapon currentWeapon)
    {
        while (true)
        {
            StartCoroutine(AIShotBurst(ShotCooldown, currentWeapon));

            yield return new WaitForSeconds(CooldownBetweenBursts);
        }
        
    }

    public override IEnumerator AIShootCoroutine(RangedWeapon currentWeapon, EnemyBase enemy)
    {
        while (true)
        {                      
            yield return new WaitForSeconds(CooldownBetweenBursts);

            if (enemy.EnableShooting() == true)
            {
                StartCoroutine(AIShotBurst(ShotCooldown, currentWeapon));
            }
        }

    }

    public override float CalculateFireRateo()
    {
        float OneBurstTime = ((SingleBurstShotNumber - 1) * ShotCooldown) + CooldownBetweenBursts;

        float BurstPerMinute = 60 / OneBurstTime;

        float firerateo = BurstPerMinute * SingleBurstShotNumber;

        return firerateo;
    }

    public override float CalculateTotalDamage(RangedWeapon CurrentWeapon)
    {
        float totalDamage = CurrentWeapon.weaponData.Damage * SingleBurstShotNumber;

        return totalDamage;
    }

    public IEnumerator PORCODIO()
    {
        yield return new WaitForSeconds(0.6f);
        feedAnime.SetActive(true);
        print("PORCAMADONNADELDIOCANEEEEEEEEEEEE");
    }
}
