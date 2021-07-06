using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [Header("Base Enemy Fields")]
    public PlayerController Player;
    public float BonusLifeWhenKilled;
    public float HP;
    public RangedWeapon MyWeapon;
    public EnemyType enemyType;

    [Header("Base Feedbacks")]
    public GameObject elecFeed;
    public DroneShake sauce;
    public float[] floatTimes;
    public Animator floatAnim;

    //enemy life bar - Joe
    [Header("UI Stuffs")]
    public Slider EnemyLifeBar;
    public Slider EnemyLifeBar2;
    public float CurrentHP;
    public float HpSmooth;
    public float TimeLateCall;

    //Melee
    public float MeleeDamage;

    [HideInInspector]
    public MedikitManager MyFeed;

    // Start is called before the first frame update
    void Start()
    {
        //picking reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();
        CurrentHP = HP;
        enemyType = EnemyType.typeA;
        StartCoroutine("floating");

        //shoot
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon, this));

        MyFeed = FindObjectOfType<MedikitManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WatchPlayer();
        //enemy life bar - Joe
        EnemyLifeBar2.value = CurrentHP * 10;
        Invoke("LateCall", TimeLateCall);
    }
        
    /// <summary>
    /// keep Watching the player
    /// </summary>
    public virtual void WatchPlayer()
    {
        transform.LookAt(Player.gameObject.transform);
    }

    /// <summary>
    /// Shooting coroutine based on the AIshooting methods
    /// </summary>
    public void Shoot()
    {
        StartCoroutine(MyWeapon.ShootingType.AIShootCoroutine(MyWeapon, this));
    }

    /// <summary>
    /// Stop shooting coroutines
    /// </summary>
    public void StopShooting()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Healing player method when the enemy die
    /// </summary>
    public void PlayerHealOnDeath()
    {
        Player.playerLife.PlayerCurrentHP -= BonusLifeWhenKilled;

        if (Player.playerLife.PlayerCurrentHP > Player.playerLife.PlayerStartingHP)
        {
            Player.playerLife.PlayerCurrentHP = Player.playerLife.PlayerStartingHP;
        }

        MyFeed.StartCoroutine("FadeInAndOut");
    }

    /// <summary>
    /// Damage enemy method
    /// </summary>
    public void DamageEnemy()
    {
        elecFeed.SetActive(true);
        sauce.enabled = true;
        print("PORCODDIO");
        HP -= Player.playerShooting.CurrentRagedWeapon.weaponData.Damage;           
        //enemy life bar - Joe
        EnemyLifeBar.value = HP * 10;
    }

    /// <summary>
    /// return true if the player is on sight and enable shooting
    /// </summary>
    /// <returns></returns>
    public bool EnableShooting()
    {
        float youAndPlayerDistance = Vector3.Distance(this.gameObject.transform.position, transform.forward);

        if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out RaycastHit hit, 500f))
        {
            //Debug.DrawRay(enemyType1.transform.position, enemyType1.transform.forward * hit.distance, Color.blue);

            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    //Melee Luca
    public void DamageMelee()
    {
        elecFeed.SetActive(true);
        sauce.enabled = true;
        HP -= MeleeDamage;
        EnemyLifeBar.value = HP * 10;
    }

    public void KatanaDamage(float Damage)
    {
        elecFeed.SetActive(true);
        sauce.enabled = true;
        HP -= Damage;
        EnemyLifeBar.value = HP * 10;
    }

    public void LateCall()
    {            
        CurrentHP = Mathf.Lerp(CurrentHP, HP, Time.deltaTime * HpSmooth);
    }

    public IEnumerator floating()
    {
        float floatIndex = Random.Range(0, floatTimes.Length);
        yield return new WaitForSeconds(floatIndex);
        floatAnim.enabled = true;
    }
}
