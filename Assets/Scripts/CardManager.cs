using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public Dialogue dialogueScript;
    public TextMeshProUGUI cardNameText;
    public GameObject cardsMenuBackground;
    public GameObject card;

    void Awake() 
    {
        dialogueScript = FindObjectOfType<Dialogue>(true);
        card = FindObjectOfType<Card1>(true);
        //name1 = FindObjectOfType<CardName1>(true);
        //name1 = GameObject.Find("Card 1").GetComponent<CardName1>();

        if (dialogue != null)
        {
            Debug.Log("Dialogue.cs found");
        }

        if (card != null)
        {
            Debug.Log("Found card");

            if (card == "Card1") 
            {
                cardNameText = CardName1.GetComponent<TextMeshProUGUI>();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cardNameText = new TextMeshProUGUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (dialogue.infoReceived_Cook)
            {
                Card1.cardNameText = "Cooking place";
            }
            else
            {
                Card1.cardNameText = "???";
            }
        }
    }
}
