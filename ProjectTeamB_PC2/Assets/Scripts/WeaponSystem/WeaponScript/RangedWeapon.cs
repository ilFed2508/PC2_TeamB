using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    /// <summary>
    /// Current weapont datas
    /// </summary>
    public WeaponData weaponData;
    /// <summary>
    /// Total Damage done by a weapon
    /// </summary>
    public float TotalDamage;
    /// <summary>
    /// Number of ammo shotted by the weapon in one minute
    /// </summary>
    public int FireRateo;
    /// <summary>
    /// Current Ammo Avaliable in the weapon
    /// </summary>
    public int CurrentAmmo;
    /// <summary>
    /// Position where projectiles are spawned from ranged weapons
    /// </summary>
    public Transform GunBarrel;
    /// <summary>
    /// Prefab of the bullet that will be shooted by this weapon
    /// </summary>
    public GameObject WeaponBulletPrefab;
    /// <summary>
    /// Type of shooting of this weapon
    /// </summary>
    public Shooting ShootingType;


    //Variabili prova per seconda canna Da ELIMINARE
    public Transform GunBarrel2;
    public GameObject WeaponBulletPrefab2;
    //----------------------------------------------

    /// <summary>
    /// Calculate the hit Damage of the weapon after a Range
    /// </summary>
    /// <param name="HitDistance"></param>
    /// <param name="Damage"></param>
    /// <param name="RangeDistance"></param>
    /// <param name="percentageDmgReduction"></param>
    /// <returns></returns>
    ///   
    public float CalculateRangeDamageDrop(float HitDistance, float Damage, float RangeDistance, float percentageDmgReduction)
    {
        if(HitDistance > RangeDistance)
        {
            float DmgReductionValue = ((Damage / 100) * percentageDmgReduction);
            float DamageReduced = Damage - DmgReductionValue;
            return DamageReduced;
        }
        else
        {
            return Damage;
        }
    }

    /// <summary>
    /// Calculate The Speed Reduced by the Weapon Weight
    /// </summary>
    /// <param name="Speed"></param>
    /// <param name="Weight"></param>
    /// <returns></returns>
    public float ApplyWeaponWeightReduction(float Speed, float Weight)
    {
        float SpeedReductionValue = ((Speed / 100) * Weight);
        float SpeedReduced = Speed - SpeedReductionValue;
        return SpeedReduced;
    }

    /// <summary>
    /// Apply Knockback to a player after he shoot
    /// </summary>
    /// <param name="currentMovingDirection"></param>
    /// <param name="playerRB"></param>
    /// <param name="knockBack"></param>
    public void ApplyWeaponKnockBack(Vector3 playerDirection, Rigidbody playerRB, float knockBack)
    {
        Vector3 reverseDirection = playerDirection * -1;
        playerRB.AddForce(reverseDirection, ForceMode.Impulse);
    }

    /// <summary>
    /// Update the value of FireRateo if it change during Play Time
    /// </summary>
    public void UpdateFireRateoValue()
    {
        float newFireRateo = ShootingType.CalculateFireRateo();

        if(FireRateo != newFireRateo)
        {
            FireRateo = Mathf.RoundToInt(newFireRateo);
        }
    }

    /// <summary>
    /// Update the value of Total Damage if it change during Play Time
    /// </summary>
    public void UpdateTotalDamageValue()
    {
        float newTotalDamage = ShootingType.CalculateTotalDamage(this);

        if (TotalDamage != newTotalDamage)
        {
            TotalDamage = Mathf.RoundToInt(newTotalDamage);
        }
    }
    
    /// <summary>
    /// Setup Method Called at the start for setup the current ammo value
    /// </summary>
    public void SetupCurrentAmmo()
    {
        CurrentAmmo = weaponData.Ammo;
    }
}
