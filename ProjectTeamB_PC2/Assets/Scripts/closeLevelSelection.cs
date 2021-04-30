using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeLevelSelection : MonoBehaviour
{
    public Canvas Canvas1, Canvas2, Canvas3;

    public void closeCanvases()
    {
        Canvas1.enabled = false;
        Canvas2.enabled = false;
        Canvas3.enabled = false;
    }
}

