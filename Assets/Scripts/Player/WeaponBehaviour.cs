using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// The properties of the weapon.
[Serializable]
public struct WeaponProps {

    public enum WeaponType { Raycast, projectile }
    public WeaponType weaponType;

    public GameObject projectile;
    public float range;
    public float spread;
    public int shots;
}

public class WeaponBehaviour : MonoBehaviour
{
    public List<WeaponProps> weaponList = new List<WeaponProps>();

    private int weaponIndex;

    private void Update()
    {
        ChangeWeapon();
        //Debug.Log(Input.GetAxisRaw("Mouse ScrollWheel"));
    }


    // Chnages the weapon
    public void ChangeWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponIndex++;
            if (weaponIndex > weaponList.Capacity)
            {
                weaponIndex = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponIndex--;

            if (weaponIndex < 0)
                weaponIndex = weaponList.Capacity;
        }

        Debug.Log(weaponList.Capacity);
    }
    
    // Fires the gun
    public void FireWeapon()
    {

    }
}