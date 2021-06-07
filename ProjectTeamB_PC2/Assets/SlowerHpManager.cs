using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerHpManager : MonoBehaviour
{
    public bool SlowerHpIsActive;


    private PlayerLifeSystem MyLife;

    [Range(0.0f, 1.0f)]
    public float TimeSpeedMultiplier;
    public float AddDamage;

    private float CopyTimeMultiplier;

    public GameObject SlowerHpIcon;

    // Start is called before the first frame update
    void Start()
    {       
        MyLife = FindObjectOfType<PlayerLifeSystem>();
        CopyTimeMultiplier = MyLife.TimeMultiplier;
        SlowerHpIsActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(SlowerHpIsActive == true)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                MyLife.TimeMultiplier = TimeSpeedMultiplier;
                SlowerHpIcon.SetActive(false);
            }            
        }

        if(SlowerHpIsActive == false)
        {
            MyLife.TimeMultiplier = CopyTimeMultiplier;
            SlowerHpIcon.SetActive(false);
        }
    }
}
