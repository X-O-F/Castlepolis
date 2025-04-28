using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public GameObject cardsMenu;

    public Dialogue dialogueScript;
    public TextMeshProUGUI cookCardName;
    public GameObject cookCard;

    public TextMeshProUGUI gardenerCardName;
    public GameObject gardenerCard;

    public TextMeshProUGUI commanderCardName;
    public GameObject commanderCard;

    public bool isActive;

    void Awake() 
    {
        dialogueScript = FindObjectOfType<Dialogue>(true);

        cardsMenu = GameObject.Find("CardsMenu");
        cookCard = GameObject.Find("CookCard");
        gardenerCard = GameObject.Find("GardenerCard");
        commanderCard = GameObject.Find("CommanderCard");
        

        if (dialogueScript != null)
        {
            Debug.Log("Dialogue.cs found");
        }
        else
        {
            Debug.Log("Dialogue.cs not found");
        }

        if (cardsMenu != null)
        {
            cardsMenu.SetActive(false);
        }
        else
        {
            Debug.Log("CardsMenu not found");
        }

        if (cookCard != null)
        {
            cookCardName = cookCard.transform.Find("CookCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("CookCard not found");
        }

        if (gardenerCard != null)
        {
            gardenerCardName = gardenerCard.transform.Find("GardenerCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("GardenerCard not found");
        }

        if (commanderCard != null)
        {
            commanderCardName = commanderCard.transform.Find("CommanderCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("CommanderCard not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Entered Update function");
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cardsMenu != null && !isActive)
            {
                cardsMenu.SetActive(true);
                isActive = true;

                Debug.Log("Menu is active");
                UpdateCardNames();
            }
            else if (cardsMenu != null && isActive)
            {
                cardsMenu.SetActive(false);
                isActive =false;

                Debug.Log("Menu has been deactivated");
            }
            else
            {
                Debug.Log("cardsMenu is null");
            }
        }
    }

    void UpdateCardNames()
    {
            if (dialogueScript.infoReceived_Cook)
            {
                cookCardName.text = "Cooking place";
            }
            else
            {
                cookCardName.text = "???";
            }

            if (dialogueScript.infoReceived_Gar)
            {
                gardenerCardName.text = "Garden";
            }
            else
            {
                gardenerCardName.text = "???";
            }

            if (dialogueScript.infoReceived_Com)
            {
                commanderCardName.text = "Castle";
            }
            else
            {
                commanderCardName.text = "???";
            }

    }
}
