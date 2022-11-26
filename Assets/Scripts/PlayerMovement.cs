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

    private void OnMovement (InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", true);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("OnFire", true);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", false);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", true);
            animator.SetBool("OnLightning", false);
            animator.SetBool("Normal", false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetBool("OnFire", false);
            animator.SetBool("OnWater", false);
            animator.SetBool("OnLightning", true);
            animator.SetBool("Normal", false);
        }
    }
}
