using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSystem : MonoBehaviour
{
    public ParticleSystem Particle;
    public string HitKill;

    private HitmarkerFather playerC;
    public string Hit;

    public float KatanaD,SlashSpeed;

    public Animator MyAnim;

    private PlayerController MyPlayer;


    Vector3 HitPoint, VoidPoint;


    private void Start()
    {
        MyPlayer = FindObjectOfType<PlayerController>();
        playerC = GameObject.Find("HitContainer").GetComponent<HitmarkerFather>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            slash();
        }
        
        if(MyPlayer.gameObject.transform.position == HitPoint)
        {
            StopAllCoroutines();
        }
    }



    public void slash()
    {
        //MyAnim.Play("KatanaSlash");
        //gameObject.GetComponent<BoxCollider>().enabled = true;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1f));
        RaycastHit Hit;
        //Vector3 HitPoint,VoidPoint;

        if (Physics.Raycast(ray, out Hit))
        {
             HitPoint = Hit.point;
        }
        else
        {
            VoidPoint = ray.GetPoint(80);
        }

        StartCoroutine(SlashLerp(1f));

               
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(Particle, spawnPos, other.transform.rotation);
            playerC.hit.SetActive(true);
            EnemyBase Enemy = other.gameObject.GetComponentInChildren<EnemyBase>();

            Enemy.KatanaDamage(KatanaD);
            AudioManager.instance.Play(Hit);

            if (Enemy.HP <= 0)
            {
                other.gameObject.GetComponent<WeaponDrop>().DropWeapon();
                Enemy.PlayerHealOnDeath();
                if ((int)Enemy.enemyType == 1)
                {
                    Enemy.Player.playerScore.AddScore(2);
                }
                if ((int)Enemy.enemyType == 2)
                {
                    Enemy.Player.playerScore.AddScore(3);
                }
                if ((int)Enemy.enemyType == 3)
                {
                    Enemy.Player.playerScore.AddScore(4);
                }
                AudioManager.instance.Play(HitKill);
                playerC.hitDeath.SetActive(true);
                playerC.hitPanel.SetActive(true);
                Destroy(other.gameObject);
            }


        }

    }*/

    IEnumerator SlashLerp(float Duration)
    {

        float TimeC = 0;

        while (TimeC < Duration)
        {
            MyPlayer.gameObject.transform.position = Vector3.Lerp(MyPlayer.gameObject.transform.position, HitPoint, Time.deltaTime * SlashSpeed);

            TimeC += Time.deltaTime;

            yield return null;
        }
    }
}
