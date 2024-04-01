using System;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static event Action OnPlayerUpgradeEvent;

    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    [Header("Setting")]
    [SerializeField] private UpgradeSetting[] settings;

    private void UpgradePlayer(int upgradeIndex)
    {
        stats.BaseDamage += settings[upgradeIndex].DamageUpgrade;
        stats.TotalDamage += settings[upgradeIndex].DamageUpgrade;
        stats.MaxHealth += settings[upgradeIndex].HealthUpgrade;
        stats.Health = stats.MaxHealth;
        stats.MaxStamina += settings[upgradeIndex].StaminaUpgrade;
        stats.Stamina = stats.MaxStamina;
        stats.CriticalChance += settings[upgradeIndex].CChanceUpgrade;
        stats.CriticalDamage += settings[upgradeIndex].CDamagepgrade;

    }

    private void AttributeCallback(AttributeType attributeType)
    {
        if (stats.AttributePoint == 0) return;
        switch (attributeType)
        {
            case AttributeType.Strength:
                UpgradePlayer(0);
                stats.Strength++;
                break;
            case AttributeType.Dexterity:
                UpgradePlayer(1);
                stats.Dexterity++;
                break;
            case AttributeType.Intelligence:
                UpgradePlayer(2);
                stats.Intelligence++;
                break;

        }
        stats.AttributePoint--;
        OnPlayerUpgradeEvent?.Invoke();
    }

    private void OnEnable()
    {
        AttributeButton.OnAttributeSelectedEvent += AttributeCallback;
    }

    private void OnDisable()
    {
        AttributeButton.OnAttributeSelectedEvent -= AttributeCallback;
    }
}

[Serializable]
public class UpgradeSetting
{
    public string Name;

    [Header("Values")]
    public float DamageUpgrade;
    public float HealthUpgrade;
    public float StaminaUpgrade;
    public float CChanceUpgrade;
    public float CDamagepgrade;
}
