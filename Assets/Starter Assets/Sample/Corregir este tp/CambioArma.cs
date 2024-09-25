using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject Fuego;
    public GameObject Hielo;
    private bool isWeapon1Active = true;

    void Update()
    {
        // Cambiar de arma con la tecla "Q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }

        // Disparar con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void SwitchWeapon()
    {
        isWeapon1Active = !isWeapon1Active;
        Fuego.SetActive(isWeapon1Active);
        Hielo.SetActive(!isWeapon1Active);
    }

    void Shoot()
    {
        if (isWeapon1Active)
        {
            Debug.Log("Disparando con el arma 1");
            // Aquí puedes añadir la lógica de disparo para el arma 1
        }
        else
        {
            Debug.Log("Disparando con el arma 2");
            // Aquí puedes añadir la lógica de disparo para el arma 2
        }
    }
}