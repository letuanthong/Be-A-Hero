using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Update()
    {

    }

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            stats.Health = 0f;
            PlayerDead();
        }
        if (stats.Health <= 0f) return;
        DamageTextController.Instance.ShowDamageText(amount, transform);
    }

    public void RecoverHealth(float amount)
    {
        stats.Health += amount;
        stats.Health = Mathf.Min(stats.Health, stats.MaxHealth);
    }

    public bool CanRecoverHealth()
    {
        return stats.Health > 0 && stats.Health < stats.MaxHealth;
    }

    private void PlayerDead()
    {
         playerAnimations.SetDeadAnimation();
         Debug.Log("Dead");
    }
}
