using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class WeaponController : Singleton<WeaponController>
{
    [Header("Config")]
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI weaponStaminaTMP;

    public void EquipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.Icon;
        weaponIcon.SetNativeSize();
        weaponIcon.gameObject.SetActive(true);
        weaponStaminaTMP.text = weapon.RequiredStamina.ToString();
        weaponStaminaTMP.gameObject.SetActive(true);
        GameController.Instance.Player.PlayerAttack.EquipWeapon(weapon);
    }
}

