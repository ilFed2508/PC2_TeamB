using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShotGun : MonoBehaviour
{
    public Animator anim;

    public string sparo;
    public string vadoAvanti;
    public string destra;
    public string sinistra;
    public string Jump;
    private Animator Camera;

    void Start()
    {
        Camera = GameObject.Find("CamerasLogic").GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool(sparo, true);
            //Camera.Play("CameraShootgunShoot");

        }
        else
        {
            anim.SetBool(sparo, false);
            anim.SetBool(vadoAvanti, false);

        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool(vadoAvanti, true);
        }
        else
        {
            anim.SetBool(vadoAvanti, false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool(destra, true);
            anim.SetBool(vadoAvanti, true);
        }
        else
        {
            anim.SetBool(destra, false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool(sinistra, true);
            anim.SetBool(vadoAvanti, true);
        }
        else
        {
            anim.SetBool(sinistra, false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool(vadoAvanti, true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool(Jump, true);
        }
        else
        {
            anim.SetBool(Jump, false);
        }

    }
}

