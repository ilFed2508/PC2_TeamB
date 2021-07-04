using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedOnTarget : MonoBehaviour
{
    public GameObject IconSlashHUD;

    // Update is called once per frame
    void Update()
    {
        CrossFeed();
    }

    public void CrossFeed()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit Hit;


        if (Physics.Raycast(ray, out Hit) && Hit.collider.CompareTag("Enemy"))
        {
            IconSlashHUD.SetActive(true);
        }
        else
        {
            IconSlashHUD.SetActive(false);
        }
    }
}
