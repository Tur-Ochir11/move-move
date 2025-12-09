using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 5f;
    public float acceleration = 0.5f;
    public float braking = 0.5f;
    [Header("Ground Check")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundCheckDistance = 0.1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Move(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Move(Vector2 input)
    {
        float targetSpeed = input.x * speed;

        float accelRate = Mathf.Abs(input.x) > 0.01f
            ? acceleration
            : braking; // 👈 braking when no input

        float newX = Mathf.MoveTowards(
            rb.linearVelocity.x,
            targetSpeed,
            accelRate * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
    }


    public void Jump()
    {
        if (!IsGrounded()) return;
        
        rb.AddForceY(jumpForce, ForceMode2D.Impulse);
    }
    

    bool IsGrounded()
    {
        return Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundCheckDistance,
            groundMask
        );
    }

}
