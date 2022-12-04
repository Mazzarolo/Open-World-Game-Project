using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector2 movement;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        PlayerStatus status = GetComponent<PlayerStatus>();

        if (!status.IsStunned())
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
