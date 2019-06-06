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

    private List<GameObject> weaponObjects = new List<GameObject>();

    private GameObject viewModel;

    private int weaponIndex;

    private void Start()
    {
        viewModel = GameObject.FindGameObjectWithTag("weaponViewModel");

        for (int i = 0; i < weaponList.Count; i++)
        {
            WeaponProperties weapon = weaponList[i];

            GameObject wepInst = Instantiate(weapon.Model, viewModel.transform);
            wepInst.transform.localScale = weapon.modelScale;

            weaponObjects.Add(wepInst);

            // Only show the first weapon.
            if (i == 0)
                weaponObjects[i].SetActive(true);
            else
                weaponObjects[i].SetActive(false);

            weaponIndex = 0;
        }
    }

    private void Update()
    {
        GameObject weapon = weaponObjects[weaponIndex];

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponIndex++;

            if (weaponIndex > weaponList.Count - 1)
                weaponIndex = 0;
            ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponIndex--;

            if (weaponIndex < 0)
                weaponIndex = weaponList.Count - 1;
            ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
        }


        #region NumberKeys
        int tempIndex = weaponIndex;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponIndex = 0;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponIndex = 1;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponIndex = 2;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weaponIndex = 3;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            weaponIndex = 4;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            weaponIndex = 5;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            weaponIndex = 6;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            weaponIndex = 7;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            weaponIndex = 8;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            weaponIndex = 9;

            if (weaponIndex < weaponList.Count)
            {
                ChangeWeapon(weaponIndex, weapon, weaponObjects[weaponIndex]);
            }
        }

        if (weaponIndex >= weaponList.Count)
            weaponIndex = tempIndex;
        #endregion

    }


    // Chnages the weapon
    public void ChangeWeapon(int index, GameObject currentWeapon, GameObject nextWeapon)
    {
        if (index < weaponList.Count)
        {
            currentWeapon.SetActive(false);
            nextWeapon.SetActive(true);
            
            // Play Sound Effect
        }
    }

    // Fires the gun
    public void FireWeapon()
    {

    }
}