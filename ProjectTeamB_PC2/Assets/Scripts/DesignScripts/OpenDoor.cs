using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject doorRight, doorLeft;
    public Transform rightOpen, leftOpen, rightClosed, leftClosed;
    public float speed;

    private bool isOpen;

    public string SuonoApertura;
    public string SuonoChiusura;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightOpen.position, Time.deltaTime * speed);
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftOpen.position, Time.deltaTime * speed);
        }
        else
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightClosed.position, Time.deltaTime * speed);
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftClosed.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            AudioManager.instance.Play(SuonoApertura);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = false;
            AudioManager.instance.Play(SuonoChiusura);
        }
    }
}
