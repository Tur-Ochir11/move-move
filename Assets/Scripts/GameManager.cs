using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
