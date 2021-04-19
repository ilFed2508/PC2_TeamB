using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    public GameObject end, HUD;

    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            end.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            HUD.SetActive(false);
        }
    }
}
