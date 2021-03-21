using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotation : MonoBehaviour
{
    public float speed;
    public GameObject canne;

    private Vector3 toRotateV;
    private Transform toRotateT;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
