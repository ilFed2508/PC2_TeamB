using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAttacco : MonoBehaviour
{
    public bool enemyCanAttack = true;
    public bool enemyIsAttacking = true;
    public float spread, attackTime, shootForce;
    public GameObject bullet;
    public Transform attackPoint;

    private float lastShotFired;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        Attack();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        lastShotFired = Time.time;

        Vector3 targetPoint;
        targetPoint = target.transform.position;

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //spread se dovesse servire
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //direzione spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);


        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);


        Invoke("Attack", attackTime);
    }
}
