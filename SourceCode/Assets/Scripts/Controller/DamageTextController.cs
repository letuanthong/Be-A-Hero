using System;
using UnityEngine;

public class DamageTextController : Singleton<DamageTextController>
{

    [Header("Config")]
    [SerializeField] private DamageText damageTextPrefab;

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamageText text = Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.SetDamageText(damageAmount);
    }
}