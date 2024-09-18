using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con elementos de UI

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 100;
    public int currentMana;
    public float manaRegenRate = 1f; // Maná regenerado por segundo
    public float manaRegenDelay = 2f; // Tiempo de espera antes de regenerar maná

    public Text manaText; // Referencia al texto de UI que muestra el maná
    public Image manaBar; // Referencia a la barra de maná en la UI

    private float lastManaUseTime;

    private void Start()
    {
        currentMana = maxMana;
        UpdateManaUI();
    }

    private void Update()
    {
        // Regenerar maná después del tiempo de espera
        if (Time.time > lastManaUseTime + manaRegenDelay && currentMana < maxMana)
        {
            RegenerateMana();
        }
    }

    public void UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            lastManaUseTime = Time.time;
            UpdateManaUI();
            Debug.Log("Maná usado: " + amount + ". Maná restante: " + currentMana);
        }
        else
        {
            Debug.Log("No hay suficiente maná!");
        }
    }

    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
        UpdateManaUI();
        Debug.Log("Maná restaurado: " + amount + ". Maná actual: " + currentMana);
    }

    private void RegenerateMana()
    {
        currentMana = Mathf.Min(currentMana + (int)(manaRegenRate * Time.deltaTime), maxMana);
        UpdateManaUI();
    }

    private void UpdateManaUI()
    {
        if (manaText != null)
        {
            manaText.text = currentMana + " / " + maxMana;
        }

        if (manaBar != null)
        {
            manaBar.fillAmount = (float)currentMana / maxMana;
        }
    }
}