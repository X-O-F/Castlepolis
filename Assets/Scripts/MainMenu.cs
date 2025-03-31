using UnityEngine;
public class MainMenu : MonoBehaviour
{
    public static string SelectedCharacter;

    public GameObject MainMenuPanel;
    public GameObject CharacterSelectPanel;

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

    public void SelectCharacter(string characterType)
    {
        SelectedCharacter = characterType; // Store the selection of the player character type for use in Game scene
    }
}
