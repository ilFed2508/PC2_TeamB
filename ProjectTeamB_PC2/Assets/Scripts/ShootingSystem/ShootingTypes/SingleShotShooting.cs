using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotShooting : Shooting
{
    

    private void Start()
    {
        
    }
    public override void ShootingAction(RangedWeapon currentWeapon)
    {
        if(CanWeaponShoot == true && currentWeapon.CurrentAmmo > 0)
        {
            Shoot(currentWeapon);
            currentWeapon.CurrentAmmo -= 1;
            StartCoroutine(WaitShotCooldown(ShotCooldown));
        }       
    }

    public override void Shoot(RangedWeapon currentWeapon)
    {
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ShootingTargetPoint = hit.point;
        }
        else
        {
            ShootingTargetPoint = ray.GetPoint(80);
        }

        Vector3 ShootingDirection = ShootingTargetPoint - currentWeapon.GunBarrel.position;

        GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab , currentWeapon.GunBarrel.position, Quaternion.identity);

        BulletInstance.transform.forward = ShootingDirection.normalized;

        BulletInstance.GetComponent<Rigidbody>().AddForce(ShootingDirection.normalized * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);
        
    }

   

    public override float CalculateFireRateo()
    {
        float firerateo = 60 / ShotCooldown;

        return firerateo;
    }

    public override float CalculateTotalDamage(RangedWeapon CurrentWeapon)
    {
        return base.CalculateTotalDamage(CurrentWeapon);
    }
}
