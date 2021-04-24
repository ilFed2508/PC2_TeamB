using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLevelSelction : MonoBehaviour
{
    public Canvas Canvas1, Canvas2, Canvas3;

    public void openCanvases()
    {
        Canvas1.enabled = true;
        Canvas2.enabled = true;
        Canvas3.enabled = true;
    }
}
