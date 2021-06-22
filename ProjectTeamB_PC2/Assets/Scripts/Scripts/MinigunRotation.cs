using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotation : MonoBehaviour
{
    public float speed;
    public GameObject canne;

    private Vector3 toRotateV;
    private Transform toRotateT;

    public Animator MiniGunAnim;

    public string sparo;
    public string vadoAvanti;
    public string destra;
    public string sinistra;
    public string Jump;
    private Animator Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("CamerasLogic").GetComponent<Animator>();
        toRotateT = canne.GetComponent<Transform>();
        toRotateV = new Vector3(canne.transform.localRotation.x * 0, canne.transform.localRotation.y * 0, canne.transform.localRotation.z * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            toRotateT.Rotate(toRotateV);          
        }
        else
        {
            MiniGunAnim.SetBool("Shoot", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            MiniGunAnim.SetBool(vadoAvanti, true);
        }
        else
        {
            MiniGunAnim.SetBool(vadoAvanti, false);

        }
    }
}
