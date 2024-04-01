using UnityEngine;

public enum WeaponType
{
    Bow,
    Sword,
    Axe
}

[CreateAssetMenu(fileName = "Weapon_")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    [Header("TypeEffect")]
    public Arrow Arrow;
    public EffectSword Effect;
    public float RequiredStamina;
}
