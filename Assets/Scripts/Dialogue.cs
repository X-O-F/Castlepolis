using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private DialogueInteraction currentInteraction;

    public void SetInteraction(DialogueInteraction interaction)
    {
        currentInteraction = interaction;
    }

    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public bool dialogueActive = false;
    public bool infoReceived_Cook = false;
    public bool infoReceived_Gar = false;
    public bool infoReceived_Com = false;
    public Button yesButton, noButton;

    private System.Action yesAction, noAction;
    
    private int index;

    [System.Serializable]
    public class npcDialogue {
        public string npcName;
        public string[] lines;
    }

    public npcDialogue[] npcDialogues;
    private string[] current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInteraction != null && currentInteraction.playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueActive)
            {
                StartDialogue(currentInteraction.npcName);
            }
            else if (textComponent.text == current[index])
            {
                NextLine();
            }

        }
    }

    public void StartDialogue(string npcName)
    {
        StopAllCoroutines();

        textComponent.text = string.Empty;
        current = null;

        foreach (var npcDialogue in npcDialogues)
        {
            if (npcDialogue.npcName == npcName)
            {
                current = npcDialogue.lines;
                if (npcDialogue.npcName == "Cook") 
                {
                    infoReceived_Cook = true;
                    Debug.Log("Info received from cook");
                }
                else if (npcDialogue.npcName == "Gardener")
                {
                    infoReceived_Gar = true;
                    Debug.Log("Info received from gardener");
                }
                else if (npcDialogue.npcName == "Commander")
                {
                    infoReceived_Com = true;
                    Debug.Log("Info received from commander");
                } 
                break;
            }
        }

        if (current == null || current.Length == 0)
        {
            Debug.Log("No dialogue found for NPC: {npcName}");
            return;
        }


        gameObject.SetActive(true);

        index = 0;
        dialogueActive = true;
        StartCoroutine(TypeLine());
    }

    public void StartCustomDialogue(string npcName, string message, System.Action onYes, System.Action onNo)
    {
        dialogueActive = true;
        gameObject.SetActive(true);

        textComponent.text = message;
        //nameText.text = npcName; todo

        yesAction = onYes;
        noAction = onNo;

        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => { yesAction?.Invoke(); HideOptions(); });
        noButton.onClick.AddListener(() => { noAction?.Invoke(); HideOptions(); });
    }

    public void ShowLine(string message)
    {
        textComponent.text = message;
    }

    void HideOptions()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach(char c in current[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (current == null) return;

        if (index < current.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = string.Empty;
            dialogueActive = false;
            gameObject.SetActive(false);
        }
    }
}