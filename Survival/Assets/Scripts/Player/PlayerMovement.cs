using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public enum movementDirection
{
    Idle,
    Horizontal,
    Up,
    Down,
    Diagonal
}
public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions _playerInput;
    private InputAction _moveAction;

    public Rigidbody2D rb;

    public float moveSpeed;
    public Vector2 vectorDirection = Vector2.zero;

    public movementDirection movementDirection;

    void Awake()
    {
        _playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _moveAction = _playerInput.GeneralMap.MovementAction;
        _moveAction.Enable();

    }
    private void OnDisable()
    {
        _moveAction.Disable();
    }

    void Update()
    {
        vectorDirection = _moveAction.ReadValue<Vector2>();

        if ((vectorDirection.x > 0 || vectorDirection.x < 0) && vectorDirection.y == 0)
        {
            movementDirection = movementDirection.Horizontal;

            if (vectorDirection.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else if (vectorDirection.y > 0 && vectorDirection.x == 0)
        {
            movementDirection = movementDirection.Up;
        }
        else if (vectorDirection.x != 0 && vectorDirection.y != 0)
        {
            movementDirection = movementDirection.Diagonal;
        }
        else if (vectorDirection == Vector2.zero)
        {
            movementDirection = movementDirection.Idle;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vectorDirection.x, vectorDirection.y).normalized * moveSpeed;
    }
}
