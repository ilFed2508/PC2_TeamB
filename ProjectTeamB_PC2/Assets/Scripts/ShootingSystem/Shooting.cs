using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shooting : MonoBehaviour
{
    /// <summary>
    /// Cooldown in seconds between one shot and the next one
    /// </summary>
    public float ShotCooldown;
    /// <summary>
    /// Let you know if the weapon can perform the shooting action
    /// </summary>
    protected bool CanWeaponShoot = true;
    /// <summary>
    /// Value that enable the automatic fire mode 
    /// </summary>
    public bool IsAutomatic;
    /// <summary>
    /// target point where your weapon will aim and shoot towards
    /// </summary>
    protected Vector3 ShootingTargetPoint;


    /// <summary>
    /// method that define the different shooting of the weapons
    /// </summary>
    /// <param name="currentWeapon"></param>
    public virtual void Shoot(RangedWeapon currentWeapon) { }

    public virtual void AIShoot(RangedWeapon currentWeapon) { }

    /// <summary>
    /// All the things that are performed in a single shooting action
    /// </summary>
    /// <param name="currentWeapon"></param>
    public virtual void ShootingAction(RangedWeapon currentWeapon) { }

    public virtual IEnumerator AIShootCoroutine(RangedWeapon currentWeapon)
    {
        yield return new WaitForSeconds(0f);
    }

    public virtual IEnumerator AIShootCoroutine(RangedWeapon currentWeapon, EnemyBase enemy)
    {
        yield return new WaitForSeconds(0f);
    }

    /// <summary>
    /// Methods that calculate the fire rateo of the current shooting type
    /// </summary>
    /// <param name="CurrentWeapon"></param>
    /// <returns></returns>
    public virtual float CalculateFireRateo()
    {
        return 0;
    }

    /// <summary>
    /// Methods that calculate the Total Damage of the current shooting type
    /// </summary>
    /// <param name="CurrentWeapon"></param>
    /// <returns></returns>
    public virtual float CalculateTotalDamage(RangedWeapon CurrentWeapon)
    {
        return CurrentWeapon.weaponData.Damage;
    }

    /// <summary>
    /// setup and activate the weapons can shoot bool
    /// </summary>
    public void SetupCanWeaponShoot()
    {
        if(CanWeaponShoot == true)
            return;
        else
            CanWeaponShoot = !CanWeaponShoot;
    }

    /// <summary>
    /// Wait the shot cooldown and disable the possibility of shooting
    /// </summary>
    /// <param name="shotCooldown"></param>
    /// <returns></returns>
    public IEnumerator WaitShotCooldown(float shotCooldown)
    {
        CanWeaponShoot = false;

        yield return new WaitForSeconds(shotCooldown);

        CanWeaponShoot = true;
    }
}
