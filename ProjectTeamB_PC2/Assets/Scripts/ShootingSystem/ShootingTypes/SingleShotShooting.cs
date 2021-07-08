using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleShotShooting : Shooting
{
    //Luca
    public CameraShake.Properties testProperties;
    public GameObject Flash;
    public Transform Parent;
    public string Suono;
    private DroneShake MyLevelZero;
    //Da eliminare più avanti
    private Animator anim;
    private ComboManager MyComboZero;

    private void Start()
    {  
        //Da eliminare più avanti
        anim = GetComponent<Animator>();
        MyLevelZero = GameObject.Find("Combo Level").GetComponent<DroneShake>();
        MyComboZero = FindObjectOfType<ComboManager>();
    }

    public override void ShootingAction(RangedWeapon currentWeapon)
    {

        if(CanWeaponShoot == true && currentWeapon.CurrentAmmo > 0)
        {
            Shoot(currentWeapon);
            currentWeapon.CurrentAmmo -= 1;
            StartCoroutine(WaitShotCooldown(ShotCooldown));
            if(currentWeapon.CurrentAmmo == 0)
            {
                AudioManager.instance.Play("ZeroFeed");
                MyLevelZero.enabled = true;
                MyLevelZero.gameObject.GetComponent<Text>().color = Color.red;
                MyComboZero.ResetComboDamage();
                MyComboZero.ZeroVFX.SetActive(true);
            }
        }
        
    }

    public override void Shoot(RangedWeapon currentWeapon)
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1f));
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

        FindObjectOfType<CameraShake>().StartShake(testProperties);

        GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab , currentWeapon.GunBarrel.position, Quaternion.identity);       

        BulletInstance.transform.forward = ShootingDirection.normalized;       

        BulletInstance.GetComponent<Rigidbody>().AddForce(ShootingDirection.normalized * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);

       

        //da giù in poi Da eliminare 
        Instantiate(Flash, Parent);
        //Da eliminare più avanti
        anim.Play("ShootAR(Def)");
        anim.SetBool("Shoot", true);

        //Audio Luca
        AudioManager.instance.Play(Suono);
    }

    public override void AIShoot(RangedWeapon currentWeapon)
    {
        GameObject BulletInstance = Instantiate(currentWeapon.WeaponBulletPrefab, currentWeapon.GunBarrel.position, Quaternion.identity);
        BulletInstance.GetComponent<EnemyBullet>().Damage = currentWeapon.weaponData.Damage;
        BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * currentWeapon.weaponData.ShootingForce, ForceMode.Impulse);
    }

    public override IEnumerator AIShootCoroutine(RangedWeapon currentWeapon)
    {
        while (true)
        {
            yield return new WaitForSeconds(ShotCooldown);
            AIShoot(currentWeapon);
        }
    }

    public override IEnumerator AIShootCoroutine(RangedWeapon currentWeapon, EnemyBase enemy)
    {
        while (true)
        {            
            yield return new WaitForSeconds(ShotCooldown);
            
            if (enemy.EnableShooting() == true)
            {
                AIShoot(currentWeapon);
            }
        }
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
    //IEnumerator lateCall()
    //{
    //    yield return new WaitForSeconds(MyLevelZero.shakeDuration);
    //    MyLevelZero.gameObject.GetComponent<Text>().color = Color.white;
    //}
}
