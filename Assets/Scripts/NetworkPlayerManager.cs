using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerManager : NetworkBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        _spriteRenderer.color = GameManager.Instance.GetRandomColor();
    }
}
