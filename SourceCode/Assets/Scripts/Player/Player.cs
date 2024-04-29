using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;

    public PlayerStamina PlayerStamina { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerAttack PlayerAttack { get; private set; }

    private PlayerAnimations animations;

    [Header("Test")]
    public ItemHealthPotion HealthPotion;
    //public ItemManaPotion StaminaPotion;

    private void Awake()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerStamina = GetComponent<PlayerStamina>();
        PlayerAttack = GetComponent<PlayerAttack>();
        animations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (HealthPotion.UseItem())
            {
                Debug.Log("Using Health Potion");
            }

            //if (StaminaPotion.UseItem())
            //{
            //    Debug.Log("Using Stamina Potion");
            //}
        }
    }

    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();

    }
}
