using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : DoorBase
{
    // Start is called before the first frame update
    void Start()
    {
        CanBeOpened = true;
    }

    // Update is called once per frame
    void Update()
    {
        OpeningDoorAnimation();
    }
}
