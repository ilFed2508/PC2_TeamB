using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedikitManager : MonoBehaviour
{
    private PlayerLifeSystem MyLife;
    public bool CanUseMedikit;

    public int NumberOfMedikit;
    public float MedikitEffect;

    public GameObject MedikitIcon;
    public Text NumberOfMedikitText;

    void Start()
    {
        MyLife = FindObjectOfType<PlayerLifeSystem>();
        CanUseMedikit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        NumberOfMedikitText.text = NumberOfMedikit.ToString();
        if (CanUseMedikit)
        {
            
            MedikitIcon.SetActive(true);
            if(Input.GetMouseButtonDown(1) && NumberOfMedikit > 0)
            {
                MyLife.PlayerCurrentHP += MedikitEffect;
                NumberOfMedikit -= 1;
            }
        }

        if (NumberOfMedikit == 0)
        {
            
            CanUseMedikit = false;
            MedikitIcon.SetActive(false);
        }
        if(!CanUseMedikit)
        {
            MedikitIcon.SetActive(false);
        }
    }
}
