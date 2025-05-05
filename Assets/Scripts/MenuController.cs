using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject teleportPanel;

    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;
        InputManager.isGamePaused = isPaused;
        menuPanel.SetActive(isPaused);
        if (isPaused)
            ShowMainPanel();
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
        teleportPanel.SetActive(false);
    }

    public void ShowHelp()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }
    
    public void ShowTeleport()
    {
        mainPanel.SetActive(false);
        teleportPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
