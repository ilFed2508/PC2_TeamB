using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float amount;
    
   

    public Vector3 initialPosition;
    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(CameraShake(0.2f));
    }

    public IEnumerator CameraShake(float magnitude)
    {
        initialPosition = myCamera.transform.localPosition;

        while (Input.GetMouseButton(0))
        {
            float movemantX = Random.Range(myCamera.transform.localPosition.x + amount, myCamera.transform.localPosition.x - amount) * magnitude;
            float movemantY = Random.Range(myCamera.transform.localPosition.y + amount, myCamera.transform.localPosition.y - amount) * magnitude;

            myCamera.transform.localPosition = new Vector3(movemantX, movemantY, 0f);

            yield return null;
        }

        myCamera.transform.localPosition = initialPosition;
    }
}
