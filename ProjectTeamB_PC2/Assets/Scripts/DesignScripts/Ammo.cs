using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public float caricatore;
    public float colpiSparati;
    public float tapTime;
    private PlayerLifeWIP playerController;
    private PlayerShooting myScript;

    void Start()
    {
        myScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        myScript.enabled = true;
        playerController = FindObjectOfType<PlayerLifeWIP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LateCall());
        }

        if (caricatore <= 0)
        {
            myScript.enabled = false;
            playerController.BulletText.gameObject.SetActive(true);
        }
        else
        {
            myScript.enabled = true;
            playerController.BulletText.gameObject.SetActive(false);
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(tapTime);
        caricatore = caricatore - colpiSparati;

    }
}
