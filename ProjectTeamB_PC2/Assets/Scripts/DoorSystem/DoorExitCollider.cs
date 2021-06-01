using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitCollider : MonoBehaviour
{
    private DoorBase DoorAttached;

    // Start is called before the first frame update
    void Start()
    {
        DoorAttached = GetComponentInParent<DoorBase>();
        if (DoorAttached == null)
        {
            Debug.Log("Metti la referenza al collider della porta!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorAttached.CanBeOpened = false;
        //DoorAttached.CurrentlyOpened = false;

        if(DoorAttached.CurrentlyOpened == true && DoorAttached.CanBeOpened == false)
            AudioManager.instance.Play(DoorAttached.ClosingSound);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
}
