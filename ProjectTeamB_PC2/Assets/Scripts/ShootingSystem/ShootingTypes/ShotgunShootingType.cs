using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    private void Start()
    {
        //Luca Animazione Pompa
        Pompa.GetComponent<Animator>();
    }

    public override void ShootingAction(RangedWeapon currentWeapon)
    {
        if (CanWeaponShoot == true && currentWeapon.CurrentAmmo > 0)
        {
            Shoot(currentWeapon);
            currentWeapon.CurrentAmmo -= 1;
            StartCoroutine(WaitShotCooldown(ShotCooldown));
        }
    }

    public override void Shoot(RangedWeapon currentWeapon)
    {
        for (int palletsShot = 0; palletsShot < PalletShotNumber; palletsShot++)
        {
            int layer_mask = LayerMask.GetMask("Player");
            Vector2 randomBloom = new Vector2(GetRandomBloomValue(Bloom), GetRandomBloomValue(Bloom));

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(randomBloom.x, randomBloom.y, 0));

            if (Physics.Raycast(ray, out RaycastHit hit,layer_mask))
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

            //Luca Animazione Pompa
            Pompa.Play("PompaShoot");

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
}
