using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSystem : MonoBehaviour
{


    private Animator MyKatanaAnimator;

    public float SlashSpeed;

    //public Animator MyAnim;

    private PlayerController MyPlayer;

    public GameObject KatanaContenitore;

    Vector3 HitPoint, VoidPoint;

    private void Start()
    {
        MyKatanaAnimator = GetComponent<Animator>();
        MyPlayer = FindObjectOfType<PlayerController>();
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

        //MyKatanaAnimator.Play("KatanaHit");

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 3f));
        RaycastHit Hit;
        

        if (Physics.Raycast(ray, out Hit))
        {
             HitPoint = Hit.point;
        }
        else
        {
            VoidPoint = ray.GetPoint(80);
        }

        if (Hit.collider.CompareTag("Enemy"))
        {
            StartCoroutine(SlashLerp(0.5f));
            MyKatanaAnimator.Play("KatanaHit");
        }
                     
    }

    public void DeactiveKatana()
    {
        
    }

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
