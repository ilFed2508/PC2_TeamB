using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour
{
    /// <summary>
    /// The Door Leaves Object
    /// </summary>
    public GameObject doorRight, doorLeft;
    /// <summary>
    /// Transforms of the Door open or closed
    /// </summary>
    public Transform rightOpen, leftOpen, rightClosed, leftClosed;
    /// <summary>
    /// Door opening Speed
    /// </summary>
    public float OpenSpeed;
    /// <summary>
    /// If the door is currently opened 
    /// </summary>
    [HideInInspector]
    public bool CurrentlyOpened;
    /// <summary>
    /// if the door can be opened
    /// </summary>
    [HideInInspector] 
    public bool CanBeOpened;
    /// <summary>
    /// Door Opening Sound
    /// </summary>
    public string OpeningSound;
    /// <summary>
    /// Door Closing Sound
    /// </summary>
    public string ClosingSound;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpeningDoorAnimation()
    {
        if (CurrentlyOpened == true && CanBeOpened == true)
        {
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightOpen.position, Time.deltaTime * OpenSpeed);
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftOpen.position, Time.deltaTime * OpenSpeed);
        }
        else
        {
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightClosed.position, Time.deltaTime * OpenSpeed);
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftClosed.position, Time.deltaTime * OpenSpeed);
        }
    }

    public void OpenDoor()
    {
        CurrentlyOpened = true;
        AudioManager.instance.Play(OpeningSound);
    }

    public void CloseDoor()
    {
        CurrentlyOpened = false;
        AudioManager.instance.Play(ClosingSound);
    }
}
