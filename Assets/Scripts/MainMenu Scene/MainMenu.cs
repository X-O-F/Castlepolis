using UnityEditor;
using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public static string SelectedCharacter;

    public GameObject MainMenuPanel;
    public GameObject CharacterSelectPanel;
    public GameObject HelpPanel;
    public GameObject DisplayPanel;

    public GameObject helpContentsPanel1;
    public GameObject helpContentsPanel2;
    public GameObject helpContentsPanel3;

    private int helpContentsIndex = 0;

    void Start()
    {
        MainMenuPanel.SetActive(true);
        CharacterSelectPanel.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        MainMenuPanel.SetActive(false);
        CharacterSelectPanel.SetActive(true);
    }

    public void OnHelpButtonClicked()
    {
        MainMenuPanel.SetActive(false);
        HelpPanel.SetActive(true);
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

    public void OnDisplayButtonClicked()
    {
        MainMenuPanel.SetActive(false);
        DisplayPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        CharacterSelectPanel.SetActive(false);
        HelpPanel.SetActive(false);
        DisplayPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void SelectCharacter(string characterType)
    {
        SelectedCharacter = characterType; // Store the selection of the player character type for use in Game scene
    }
}
