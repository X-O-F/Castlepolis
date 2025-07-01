using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    public GameObject cardsMenu;

    public Dialogue dialogueScript;
    public TextMeshProUGUI cookCardName;
    public GameObject cookCard;
    public Sprite cookCardActivated;
    public Image cookCardImage;

    public TextMeshProUGUI gardenerCardName;
    public GameObject gardenerCard;
    public Sprite gardenerCardActivated;
    public Image gardenerCardImage;

    public TextMeshProUGUI commanderCardName;
    public GameObject commanderCard;
    public Sprite commanderCardActivated;
    public Image commanderCardImage;

    private Color cardOpacity;

    public GameObject cardInfo;
    public TextMeshProUGUI cardInfoText;
    public bool infoActive = false;
    public bool cardsActive = false;

    void Awake() 
    {
        dialogueScript = FindObjectOfType<Dialogue>(true);

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

        if (cardInfo != null)
        {
            cardInfoText = cardInfo.transform.Find("CardInfoBackground/CardInfoText").GetComponent<TextMeshProUGUI>();
            cardInfo.SetActive(false);
            Debug.Log("CardInfo has been set to false");
        }
        else
        {
            Debug.Log("CardInfo not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Entered Update function");
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cardsMenu != null && !cardsActive)
            {
                MusicManager.instance.PlayPopSFX();
                cardsMenu.SetActive(true);
                cardsActive = true;

                Debug.Log("Menu is active");
                UpdateCardNames();
            }
            else if (cardsMenu != null && cardsActive)
            {
                MusicManager.instance.PlayPopSFX();
                CloseInfoMenu();
                CloseCardsMenu();
            }
            else if (cardsMenu == null)
            {
                Debug.Log("cardsMenu is null");
            }
        }
    }

    void UpdateCardNames()
    {
            if (dialogueScript.infoReceived_Cook)
            {
                cookCardName.text = "Restaurant";
                cookCardImage.sprite = cookCardActivated;
                cardOpacity = cookCardImage.color;
                cardOpacity.a = 1f;
                cookCardImage.color = cardOpacity;
            }
            else
            {
                cookCardName.text = "???";
                cardOpacity = cookCardImage.color;
                cardOpacity.a = 0.5f;
                cookCardImage.color = cardOpacity;
            }

            if (dialogueScript.infoReceived_Gar)
            {
                gardenerCardName.text = "Garden";
                gardenerCardImage.sprite = gardenerCardActivated;
                cardOpacity = gardenerCardImage.color;
                cardOpacity.a = 1f;
                gardenerCardImage.color = cardOpacity;
            }
            else
            {
                gardenerCardName.text = "???";
                cardOpacity = gardenerCardImage.color;
                cardOpacity.a = 0.5f;
                gardenerCardImage.color = cardOpacity;
            }

            if (dialogueScript.infoReceived_Com)
            {
                commanderCardName.text = "Castle";
                commanderCardImage.sprite = commanderCardActivated;
                cardOpacity = commanderCardImage.color;
                cardOpacity.a = 1f;
                commanderCardImage.color = cardOpacity;
            }
            else
            {
                commanderCardName.text = "???";
                cardOpacity = commanderCardImage.color;
                cardOpacity.a = 0.5f;
                commanderCardImage.color = cardOpacity;
            }

    }

    public void ShowCardInfo(string npc) 
    {
        Debug.Log("Entered ShowCardInfo() function");
        switch (npc)
        {
            case "Cook":
                if (dialogueScript.infoReceived_Cook && !infoActive)
                {
                    Debug.Log("Cook card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "Info about cooking stuff";
                }
                else
                {
                    Debug.Log("Card is not unlocked yet");
                }
                break;

            case "Gardener":
                if (dialogueScript.infoReceived_Gar && !infoActive)
                {
                    Debug.Log("Gardener card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "Info about garden";
                }
                else
                {
                    Debug.Log("Card is not unlocked yet");
                }
                break;

            case "Commander":
                if (dialogueScript.infoReceived_Com && !infoActive)
                {
                    Debug.Log("Commander card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "Info about castle";
                }  
                else
                {
                   Debug.Log("Card is not unlocked yet");
                }   
                break;

        }

    }

    public void CloseCardsMenu()
    {
        cardsMenu.SetActive(false);
        cardsActive = false;
        Debug.Log("Closed CardsMenu");
    }

    public void CloseInfoMenu()
    {
        cardInfo.SetActive(false);
        cardsMenu.SetActive(true);
        infoActive = false;
        Debug.Log("Closed CardInfo menu");
    }
}
