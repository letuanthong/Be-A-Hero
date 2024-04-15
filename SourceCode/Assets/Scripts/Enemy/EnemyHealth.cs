using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private float health;

    public float CurrentHealth { get; private set; }

    private EnemyAnimations enemyAnimations;
    private EnemyAI enemyAI;
    private EnemyLoot enemyLoot;

    private void Awake()
    {
        enemyAnimations = GetComponent<EnemyAnimations>();
        enemyAI = GetComponent<EnemyAI>();
        enemyLoot = GetComponent<EnemyLoot>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0f)
        {
            DisableEnemy();
            QuestController.Instance.AddProgress("Kill1Enemy", 1);
            QuestController.Instance.AddProgress("Kill5Enemy", 1);
            QuestController.Instance.AddProgress("Kill10Enemy", 1);
        }
        else
        {
            DamageTextController.Instance.ShowDamageText(amount, transform);
        }
    }

    private void DisableEnemy()
    {
        enemyAnimations.SetDeadAnimation();
        enemyAI.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        //OnEnemyDeadEvent?.Invoke();
        GameController.Instance.AddPlayerExp(enemyLoot.ExpDrop);
    }
}

