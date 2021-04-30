using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComboDamage : MonoBehaviour
{
    
    public float danno;
    
    public RangedWeapon CurrentRagedWeapon;

    private PlayerController playerController;

    public ComboManager comboController;

    // Start is called before the first frame update
    void Start()
    {
        comboController = FindObjectOfType<ComboManager>();
        CurrentRagedWeapon = FindObjectOfType<RangedWeapon>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ComboDamage()
    {
       
    }
}
