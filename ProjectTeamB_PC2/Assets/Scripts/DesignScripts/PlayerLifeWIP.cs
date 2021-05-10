using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeWIP : MonoBehaviour
{
    public float lifeTimer, BulletTimer, damageTaken, MaxPlayerLife, DelayCountdownHealth;

    public Text HPText, BulletText, BulletText2;

    public GameObject mortePanel;

    private Ammo Munizioni;


    public bool perdoVita;

    public bool perdoVitaSempre;

    public bool Carica;

    private Coroutine lastcallcoroutine;

    public void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        HPText.text = lifeTimer.ToString("N1");
    }

    // Update is called once per frame
    void Update()
    {
        Munizioni = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Ammo>();
        

        

        HPText.text = lifeTimer.ToString("N1");

        if (BulletTimer != 0 && Carica)
        {
            BulletTimer -= Time.deltaTime;          
        }

        if (BulletTimer <= 0 && perdoVita)
        {
           lifeTimer -= Time.deltaTime;        
        }

        if (lifeTimer <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            mortePanel.SetActive(true);
        }

        if (perdoVitaSempre)
        {
            lifeTimer -= Time.deltaTime;
            HPText.text = lifeTimer.ToString("N1");
        }
        BulletText2.text = Munizioni.caricatore.ToString("N1");
    }

    public IEnumerator LastCall()
    {

        yield return new WaitForSeconds(DelayCountdownHealth);

        while (lifeTimer > MaxPlayerLife)
        {

            lifeTimer -= Time.fixedDeltaTime;
            yield return null;

        }

        lastcallcoroutine = null;
    }

    void FixedUpdate()
    {
        if (lifeTimer > MaxPlayerLife && lastcallcoroutine == null)
        {
            lastcallcoroutine = StartCoroutine(LastCall());
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyBullet"))
        {
            Debug.Log("DIObastardo" + lifeTimer);
            lifeTimer -= damageTaken;
        }
    }

    public void ChiVuoiTu()
    {
        lifeTimer -= Time.fixedDeltaTime;
    }
}
