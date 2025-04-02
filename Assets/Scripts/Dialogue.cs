using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool dialogueActive = false;
    
    private int index;
    private DialogueInteraction interaction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        interaction = FindObjectOfType<DialogueInteraction>();
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueActive)
            {
                StartDialogue();
            }
            else
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }

        }
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);

        index = 0;
        dialogueActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueActive = false;
            textComponent.text = string.Empty;
        }
    }
}