using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodModeUI : MonoBehaviour
{
    public Toggle GodModeToggle;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("GodmodeActivated") == false)
        {
            PlayerPrefs.SetInt("GodmodeActivated", 0);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveGodmode()
    {
        int godModeActive = PlayerPrefs.GetInt("GodmodeActivated");

        if(GodModeToggle.isOn == true)
        {
            PlayerPrefs.SetInt("GodmodeActivated", 1);
            PlayerPrefs.Save();
        }
        else 
        {
            PlayerPrefs.SetInt("GodmodeActivated", 0);
            PlayerPrefs.Save();
        }
    }
}
