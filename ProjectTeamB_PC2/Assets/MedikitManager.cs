using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedikitManager : MonoBehaviour
{
    private PlayerLifeSystem MyLife;
    public bool CanUseMedikit;

    public int NumberOfMedikit;
    public float MedikitEffect;

    void Start()
    {
        MyLife = FindObjectOfType<PlayerLifeSystem>();
        CanUseMedikit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanUseMedikit)
        {
            if(Input.GetKeyDown(KeyCode.M) && NumberOfMedikit > 0)
            {
                MyLife.PlayerCurrentHP += MedikitEffect;
                NumberOfMedikit -= 1;
            }
        }

        if (NumberOfMedikit == 0)
        {
            CanUseMedikit = false;
        }
    }
}
