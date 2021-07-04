using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedOnTarget : MonoBehaviour
{
    public GameObject IconSlashHUD;
    private KatanaSystem MyTimeForKatana;

    public void Start()
    {
        MyTimeForKatana = FindObjectOfType<KatanaSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        CrossFeed();
    }

    public void CrossFeed()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit Hit;

               
            if (Physics.Raycast(ray, out Hit) && Hit.collider.CompareTag("Enemy") && MyTimeForKatana.TimeToUseKatana <= 0)
            {
                IconSlashHUD.SetActive(true);
            }
            else
            {
                IconSlashHUD.SetActive(false);
            }
        
    }
}
