using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject teleportPanel;
    [SerializeField] private GameObject helpContentsPanel1;
    [SerializeField] private GameObject helpContentsPanel2;
    [SerializeField] private GameObject helpContentsPanel3;

    private int helpContentsIndex = 0;

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
        helpContentsPanel1.SetActive(true);
        helpContentsPanel2.SetActive(false);
        helpContentsPanel3.SetActive(false);
        helpContentsIndex = 1;
    }

    public void NextHelpPanel()
    {
        if (helpContentsIndex == 1)
        {
            helpContentsIndex = 2;
            helpContentsPanel1.SetActive(false);
            helpContentsPanel2.SetActive(true);
        }
        else if (helpContentsIndex == 2)
        {
            helpContentsIndex = 3;
            helpContentsPanel2.SetActive(false);
            helpContentsPanel3.SetActive(true);
        }
        else if (helpContentsIndex == 3)
        {
            helpContentsIndex = 1;
            helpContentsPanel1.SetActive(true);
            helpContentsPanel3.SetActive(false);
        }
    }

    public void PreviousHelpPanel()
    {
        if (helpContentsIndex == 3)
        {
            helpContentsIndex = 2;
            helpContentsPanel3.SetActive(false);
            helpContentsPanel2.SetActive(true);
        }
        else if (helpContentsIndex == 2)
        {
            helpContentsIndex = 1;
            helpContentsPanel2.SetActive(false);
            helpContentsPanel1.SetActive(true);
        }
        else if (helpContentsIndex == 1)
        {
            helpContentsIndex = 3;
            helpContentsPanel1.SetActive(false);
            helpContentsPanel3.SetActive(true);
        }
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
