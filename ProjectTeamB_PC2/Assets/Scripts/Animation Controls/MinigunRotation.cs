using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotation : MonoBehaviour
{
    /// <summary>
    /// Turning Speed of the Weapon Barrel
    /// </summary>
    public float speed;
    /// <summary>
    /// Barrel Of the Weapon
    /// </summary>
    public GameObject MinigunBarrel;
    /// <summary>
    /// Rotation Vector to apply
    /// </summary>
    private Vector3 toRotateV;
    /// <summary>
    /// Animator Component attached to minigun
    /// </summary>
    private Animator MiniGunAnim;

    public string sparo;
    public string vadoAvanti;
    public string destra;
    public string sinistra;
    public string Jump;

    // Start is called before the first frame update
    void Start()
    {
        //minigun reference pick
        MiniGunAnim = GetComponent<Animator>();
        if(MiniGunAnim == null)
        {
            Debug.Log("Inserisci minigun Animator!");
        }

        toRotateV = new Vector3(0f,0f, MinigunBarrel.transform.localRotation.z * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MinigunBarrel.transform.Rotate(toRotateV);          
        }
        else
        {
            MiniGunAnim.SetBool("Shoot", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            MiniGunAnim.SetBool(vadoAvanti, true);
        }
        else
        {
            MiniGunAnim.SetBool(vadoAvanti, false);

        }
    }
}
