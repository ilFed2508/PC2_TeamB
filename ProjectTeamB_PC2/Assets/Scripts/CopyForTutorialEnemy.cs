using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyForTutorialEnemy : MonoBehaviour
{
    [Header("Base Enemy Fields")]
    public PlayerController Player;
    public float BonusLifeWhenKilled;
    public float HP;
    public RangedWeapon MyWeapon;

    //image feed enemies in shooting - Joe
    public Image Attention;
    public Image RedEye;

    //enemy life bar - Joe
    public Slider EnemyLifeBar;
    public Slider EnemyLifeBar2;
    public float CurrentHP;
    public float HpSmooth;
    public float TimeLateCall;

    //Animazioni
    public Animator EnemyAnim;
    public string Animazione;

    //Melee
    public float MeleeDamage;

    // Start is called before the first frame update
    void Start()
    {
        //picking reference
        Player = FindObjectOfType<PlayerController>();
        MyWeapon = GetComponent<RangedWeapon>();
        CurrentHP = HP;
        StartCoroutine(ImageFeed());
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
    public void WatchPlayer()
    {
        transform.LookAt(Player.gameObject.transform);
    }

    public void PlayerHealOnDeath()
    {
        Player.playerLife.PlayerCurrentHP += BonusLifeWhenKilled;

        if (Player.playerLife.PlayerCurrentHP > Player.playerLife.PlayerStartingHP)
        {
            Player.playerLife.PlayerCurrentHP = Player.playerLife.PlayerStartingHP;
        }
    }

    /// <summary>
    /// Damage enemy method
    /// </summary>
    public void DamageEnemy()
    {
        HP -= Player.playerShooting.CurrentRagedWeapon.weaponData.Damage;
        //enemy life bar - Joe
        EnemyLifeBar.value = HP * 10;
        EnemyAnim.SetBool(Animazione, true);
    }



    //Melee Luca
    public void DamageMelee()
    {
        HP -= MeleeDamage;
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

    public void LateCall()
    {
        CurrentHP = Mathf.Lerp(CurrentHP, HP, Time.deltaTime * HpSmooth);
    }

}
