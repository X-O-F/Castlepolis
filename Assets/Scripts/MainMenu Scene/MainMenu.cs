using UnityEditor;
using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public static string SelectedCharacter;

    public GameObject MainMenuPanel;
    public GameObject CharacterSelectPanel;
    public GameObject HelpPanel;
    public GameObject DisplayPanel;

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
