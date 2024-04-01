using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector2 MoveDirection => moveDirection;
    private Player player;
    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    private void Update()
    {
        ReadMoment();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerAttack.IsAttacking == true) return;
        if (player.Stats.Health <= 0) return;
        rb.MovePosition(rb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMoment()
    {
        if (playerAttack.IsAttacking == true) return;
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBool(false);
            return;
        }
        playerAnimations.SetMoveBool(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
