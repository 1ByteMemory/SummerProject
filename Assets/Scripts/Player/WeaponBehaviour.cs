using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// The properties of the weapon.
[Serializable]
public struct WeaponProperties {

    public enum WeaponType { Raycast, projectile }
    public WeaponType weaponType;

    [Header("Visuals")]
    public GameObject Model;
    public Vector3 modelScale;
    public GameObject projectile;

    [Header("Stats")]
    public float range;
    public float spread;
    public int shots;
    public float shotSpeed;
    public int ammoRequired;
    
}

public class WeaponBehaviour : MonoBehaviour
{
    public List<WeaponProperties> weaponList = new List<WeaponProperties>();

    private GameObject viewModel;

    private int weaponIndex;

    private void Start()
    {
        viewModel = GameObject.FindGameObjectWithTag("weaponViewModel");

        for (int i = 0; i < weaponList.Count; i++)
        {
            WeaponProperties weapon = weaponList[i];
            Debug.Log(weapon.Model);
            
            GameObject wep = Instantiate(weapon.Model, viewModel.transform);
            wep.transform.localScale = weapon.modelScale;

            // Only show the first weapon.
            if (i == 0)
                weapon.Model.SetActive(true);
            else
                weapon.Model.SetActive(false);

            weaponIndex = 0;
        }
    }

    private void Update()
    {
        ChangeWeapon();
    }


    // Chnages the weapon
    public void ChangeWeapon()
    {
        // I need to access a refernce to the instatiated child, not the model of weaponProperties
        GameObject weapon = weaponList[weaponIndex].Model;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weapon.SetActive(false);
            weaponIndex++;

            if (weaponIndex > weaponList.Count - 1)
                weaponIndex = 0;

            weapon = weaponList[weaponIndex].Model;
            weapon.SetActive(true);
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weapon.SetActive(false);
            weaponIndex--;

            if (weaponIndex < 0)
                weaponIndex = weaponList.Count - 1;

            weapon = weaponList[weaponIndex].Model;
            weapon.SetActive(true);
        }
    }

    // Fires the gun
    public void FireWeapon()
    {

    }
}