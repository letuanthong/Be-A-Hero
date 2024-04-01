using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/Health Potion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("Config")]
    public float HealthValue;

    public override bool UseItem()
    {
        if (GameController.Instance.Player.PlayerHealth.CanRecoverHealth())
        {
            GameController.Instance.Player.PlayerHealth.RecoverHealth(HealthValue);
            return true;
        }

        return false;
    }
}