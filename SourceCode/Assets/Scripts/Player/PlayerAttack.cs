using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPositions;

    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private PlayerMoment playerMovement;
    private PlayerStamina playerStamina;

    private Transform currentAttackPosition;
    private float currentAttackRotation;

    private Coroutine attackCoroutine;
    public Weapon CurrentWeapon { get; set; }

    private bool isAttacking = false;

    public bool IsAttacking
    {
        get { return isAttacking; }
    }

    private void Awake()
    {
        actions = new PlayerActions();
        playerMovement = GetComponent<PlayerMoment>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerStamina = GetComponent<PlayerStamina>();
    }

    private void Start()
    {
        WeaponController.Instance.EquipWeapon(initialWeapon);
        actions.Attack.ClickAttack.performed += ctx => Attack();
    }

    private void Update()
    {
        GetFirePosition();
        //RegenerateStamina();
    }

    private void Attack()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(IEAttack());
    }

    private IEnumerator IEAttack()
    {
            if (currentAttackPosition == null) yield break;
            if (CurrentWeapon.WeaponType == WeaponType.Bow)
            {
                if (playerStamina.CurrentStamina < CurrentWeapon.RequiredStamina)
                {
                    isAttacking = false;
                    playerAnimations.SetAttackSwordAnimation(false);
                    yield break;
                }
                BowAttack();
                isAttacking = true;
                playerAnimations.SetAttackBowAnimation(true);

                yield return new WaitForSeconds(0.5f);

                isAttacking = false;
                playerAnimations.SetAttackBowAnimation(false);
            }
            else
            {
                if (playerStamina.CurrentStamina < CurrentWeapon.RequiredStamina)
                {
                    isAttacking = false;
                    playerAnimations.SetAttackSwordAnimation(false);
                    yield break;
                }
                MeleeAttack();
                isAttacking = true;
                playerAnimations.SetAttackSwordAnimation(true);

                yield return new WaitForSeconds(0.5f);

                isAttacking = false;
                playerAnimations.SetAttackSwordAnimation(false);
            }

    }

    private void BowAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Arrow projectile = Instantiate(CurrentWeapon.Arrow,currentAttackPosition.position, rotation);
        projectile.Direction = Vector3.up;
        projectile.Damage = GetAttackDamage();
        playerStamina.UseStamina(CurrentWeapon.RequiredStamina);

    }

    private void MeleeAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        EffectSword projectile = Instantiate(CurrentWeapon.Effect, currentAttackPosition.position, rotation);
        projectile.Direction = Vector3.up;
        projectile.Damage = GetAttackDamage();
        playerStamina.UseStamina(CurrentWeapon.RequiredStamina);
    }

    private float GetAttackDamage()
    {
        float damage = stats.BaseDamage;
        damage += CurrentWeapon.Damage;
        float randomPerc = Random.Range(0f, 100);
        Debug.Log(randomPerc);
        if (randomPerc <= stats.CriticalChance)
        {
            damage += damage * (stats.CriticalDamage / 100f);
        }

        return damage;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;
        stats.TotalDamage = stats.BaseDamage + CurrentWeapon.Damage;
    }

    private void GetFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPosition = attackPositions[1];
                currentAttackRotation = -90f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[3];
                currentAttackRotation = -270f;
                break;
        }

        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPosition = attackPositions[0];
                currentAttackRotation = 0f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[2];
                currentAttackRotation = -180f;
                break;
        }
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void RegenerateStamina()
    {
        // Code để hồi phục stamina ở đây
        if (isAttacking == false)
        {
            playerStamina.RegainStamina();
        }
        if (attackCoroutine != null)
        {
            StartCoroutine(IEAttack());
        }
        // Sau khi hồi phục stamina, gọi lại coroutine IEAttack
    }

}

