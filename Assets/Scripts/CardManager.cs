using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public Dialogue dialogueScript;
    public TextMeshProUGUI textComponent;
    public CardName name;

    void Awake() 
    {
        dialogueScript = FindObjectOfType<Dialogue>(true);
        name = FindObjectOfType<CardName>(true);

        if (dialogue != null)
        {
            Debug.Log("Dialogue.cs found");
        }

        if (name != null)
        {
            Debug.Log("Found card name");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (dialogue.infoReceived_Cook)
            {
                name.textComponent = "Cooking place";
            }
            else
            {
                name.textComponent = "???";
            }
        }
    }
}
