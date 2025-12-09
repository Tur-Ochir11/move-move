using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerMovement : NetworkBehaviour
{
    public float speed = 5f;

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
    }

    public void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01f) return;
        
        rb.AddForce( direction * speed, ForceMode2D.Impulse);
    }
}
