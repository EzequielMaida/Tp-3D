using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> weapons;
    private int currentWeaponIndex = 0;

    void Start()
    {
        SwitchToWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // Cambiar arma con la rueda del ratón
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0f)
        {
            SwitchToNextWeapon();
        }
        else if (scrollWheel < 0f)
        {
            SwitchToPreviousWeapon();
        }

        // Cambiar arma con teclas numéricas
        for (int i = 0; i < weapons.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchToWeapon(i);
            }
        }
    }

    void SwitchToNextWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        SwitchToWeapon(currentWeaponIndex);
    }

    void SwitchToPreviousWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Count) % weapons.Count;
        SwitchToWeapon(currentWeaponIndex);
    }

    void SwitchToWeapon(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}