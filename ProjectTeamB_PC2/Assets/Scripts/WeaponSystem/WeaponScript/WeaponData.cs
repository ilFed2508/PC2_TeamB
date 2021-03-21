using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Create WeaponData")]
public class WeaponData : ScriptableObject
{
    /// <summary>
    /// Ammo Amount value of a weapon
    /// </summary>
    public int Ammo;
    /// <summary>
    /// Starting damage value at the start of the game
    /// </summary>
    public float StartingDamage;
    /// <summary>
    /// Damage value of a single projectile
    /// </summary>
    public float Damage;
    /// <summary>
    /// First Projectile Damage percentage buff
    /// </summary>
    public float FirstProjectileDamage;
    /// <summary>
    /// Percentage slow of the weapon
    /// </summary>
    public float Weight;
    /// <summary>
    /// The Distance where the damage reduction is active
    /// </summary>
    public float Range;
    /// <summary>
    /// Percentage damage reduction after the range distance
    /// </summary>
    public float RangeDmgReduction;    
    /// <summary>
    /// Amount of force that knockback the player when he shoot with this weapon
    /// </summary>
    public float RecoilKnockBack;
    /// <summary>
    /// Amount of force the weapon give to the projectile shooted
    /// </summary>
    public float ShootingForce;
    
}
