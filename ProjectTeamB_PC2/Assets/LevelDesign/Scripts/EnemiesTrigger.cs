using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    private DetectedActDeact end, hud;
    private GameObject guns, hitContainer, ePickUp, pausePanel, deathPanel, HUD;
   

    // Start is called before the first frame update
    void Start()
    {
        end = GameObject.Find("WIN").GetComponent<DetectedActDeact>();
        hud = GameObject.Find("HUD").GetComponent<DetectedActDeact>();
        guns = GameObject.Find("WeaponSlot");
        hitContainer = GameObject.Find("HitContainer");
        ePickUp = GameObject.Find("E-Pickup");
        pausePanel = GameObject.Find("Pause Panel");
        deathPanel = GameObject.Find("DeathPanel");
        HUD = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(pausePanel);
            Destroy(deathPanel);
            Destroy(HUD);
            Destroy(hitContainer);
            Destroy(guns);
            end.thing.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            hud.thing.SetActive(false);
            //guns.SetActive(false);
            //hitContainer.SetActive(false);
            ePickUp.SetActive(false);
        }
    }
}
