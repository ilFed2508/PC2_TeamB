using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCrossair : MonoBehaviour
{

    public GameObject CrossAR;
    public GameObject CrossSG;
    public GameObject CrossMG;
    public GameObject CrossSMG;

    private GameObject Parent;

    public GameObject AR;
    public GameObject SG;
    public GameObject MG;
    public GameObject SMG;



    void Update()
    {
        Parent = GameObject.FindGameObjectWithTag("AR");

        if (Parent)
        {
            Debug.Log("Trovato" + Parent.name);
        }

        if (Parent.CompareTag("AR") == true)
        {
            CrossAR.SetActive(true);
            CrossMG.SetActive(false);
            CrossSG.SetActive(false);
            CrossSMG.SetActive(false);
        }
        if (Parent.name == "MitragliettaContenitore")
        {
            CrossAR.SetActive(false);
            CrossMG.SetActive(false);
            CrossSG.SetActive(false);
            CrossSMG.SetActive(true);
        }
        if (Parent.name == "MiniGunContenitore")
        {
            CrossAR.SetActive(false);
            CrossMG.SetActive(true);
            CrossSG.SetActive(false);
            CrossSMG.SetActive(false);
        }
        if (Parent.name == "PompaContenitore")
        {
            CrossAR.SetActive(false);
            CrossMG.SetActive(false);
            CrossSG.SetActive(true);
            CrossSMG.SetActive(false);
        }
    }
}
