﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float lifeTimer, BulletTimer, damageTaken;

    public Text HPText, BulletText;

    // Start is called before the first frame update
    void Start()
    {
        HPText.text = lifeTimer.ToString("N1");      
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = lifeTimer.ToString("N1");

        if (BulletTimer != 0)
        {
            BulletTimer -= Time.deltaTime;
            BulletText.text = BulletTimer.ToString("N1");
        }

        if(BulletTimer <= 0)
        {
            lifeTimer -= Time.deltaTime;
            //HPText.text = lifeTimer.ToString("N1");
        }

        Debug.Log("BulletTimer" + Mathf.Round(BulletTimer));
        Debug.Log("lifeTimer" + Mathf.Round(lifeTimer));
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            Debug.Log("DIObastardo" + lifeTimer);
            lifeTimer -= damageTaken;
        }
    }
}
