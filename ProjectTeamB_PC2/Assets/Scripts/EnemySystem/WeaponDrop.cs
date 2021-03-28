using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    //public Rigidbody RB;
    public WeaponDatabase weaponDatabase;
    public LayerMask WeaponDropLayer;
    private int WeapondropCounter;

    public GameObject dropWeapon;

    public void Start()
    {
        weaponDatabase = FindObjectOfType<WeaponDatabase>();
        WeapondropCounter = 0;
    }

    public void DropWeapon()
    {
        if(WeapondropCounter == 0)
        {
            Instantiate(dropWeapon, CalculateWeaponPosition(), Quaternion.identity);
            WeapondropCounter++;
        }
        
    }

    public Vector3 CalculateWeaponPosition()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50f, WeaponDropLayer);

        Vector3 WeaponSpawnPoint = hit.point + new Vector3(0f, 2f, 0f);

        return WeaponSpawnPoint;
    } 

    public GameObject RandomWeaponDrop()
    {
        int RandomIndex = Random.Range(0, weaponDatabase.Weapons.Length);
        return weaponDatabase.Weapons[RandomIndex];
    }
}
