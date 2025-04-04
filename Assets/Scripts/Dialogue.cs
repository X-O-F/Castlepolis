using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        Debug.Log("Dialogue is being updated.");

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
        Debug.Log("Dialogue is starting.");

        StopAllCoroutines();

        textComponent.text = string.Empty;
        current = null;

        foreach (var npcDialogue in npcDialogues)
        {
            if (npcDialogue.npcName == npcName)
            {
                current = npcDialogue.lines;
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

    IEnumerator TypeLine()
    {
        Debug.Log("Lines are being printed.");

        textComponent.text = string.Empty;
        foreach(char c in current[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        Debug.Log("Moving to next line.");
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