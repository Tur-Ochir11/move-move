using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject menuButton;
    public GameObject closeMenuButton;
    
    public void SetActivateMenu(bool isActive)
    {
        menuScreen.SetActive(isActive);
        menuButton.SetActive(!isActive);
        closeMenuButton.SetActive(isActive);
    }
}
