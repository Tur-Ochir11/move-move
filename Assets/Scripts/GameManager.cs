using System;
using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Color[] colors;
    public void Awake()
    {
        Instance = this;
    }

    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Starting Host");
    }
    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
        Debug.Log("Starting Client");
    }

    public Color GetRandomColor()
    {
        return colors[UnityEngine.Random.Range(0, colors.Length)];
    }

}
