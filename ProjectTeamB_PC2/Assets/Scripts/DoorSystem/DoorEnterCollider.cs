using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterCollider : MonoBehaviour
{
    private DoorBase DoorAttached;

    // Start is called before the first frame update
    void Start()
    {
        DoorAttached = GetComponentInParent<DoorBase>();
        if(DoorAttached == null)
        {
            Debug.Log("Metti la referenza al collider della porta!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoorAttached.CurrentlyOpened = true;

            if(DoorAttached.CanBeOpened == true)
                AudioManager.instance.Play(DoorAttached.OpeningSound);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoorAttached.CurrentlyOpened = false;
            
            if (DoorAttached.CanBeOpened == true)
                AudioManager.instance.Play(DoorAttached.ClosingSound);
        }

    }
}
