using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public float CurrentStamina { get; private set; }

    private void Start()
    {
        ResetMana();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    UseStamina(1f);
        //}
    }

    public void UseStamina(float amount)
    {
        stats.Stamina = Mathf.Max(stats.Stamina -= amount, 0f);
        CurrentStamina = stats.Stamina;
    }

    public void RegainStamina()
    {
        CurrentStamina++;
    }

    public void ResetMana()
    {
        CurrentStamina = stats.MaxStamina;
    }
}
