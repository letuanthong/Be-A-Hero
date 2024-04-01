using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Strength,
    Dexterity,
    Intelligence
}

[CreateAssetMenu(fileName ="PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Stamina")]
    public float Stamina;
    public float MaxStamina;

    [Header("Exp")]
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelExp;
    [Range(1f,100f)]public float ExpMultiplier;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChance;
    public float CriticalDamage;

    [Header("Attributes")]
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int AttributePoint;

    [HideInInspector] public float TotalDamage;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Stamina = MaxStamina;
        Level = 1;
        CurrentExp = 0f;
        NextLevelExp = InitialNextLevelExp;
        BaseDamage = 2f;
        CriticalChance = 10f;
        CriticalDamage = 50f;
        Strength = 0;
        Dexterity = 0;
        Intelligence = 0;
        AttributePoint = 0;
    }
}
