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

    public TextMeshProUGUI workerCardName;
    public GameObject workerCard;
    public Sprite workerCardActivated;
    public Image workerCardImage;

    public TextMeshProUGUI farmerCardName;
    public GameObject farmerCard;
    public Sprite farmerCardActivated;
    public Image farmerCardImage;

    public TextMeshProUGUI monkCardName;
    public GameObject monkCard;
    public Sprite monkCardActivated;
    public Image monkCardImage;

    // same stuff for cats card here

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

        if (workerCard != null)
        {
            workerCardName = workerCard.transform.Find("WorkerCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("WorkerCard not found");
        }

        if (farmerCard != null)
        {
            farmerCardName = farmerCard.transform.Find("FarmerCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("FarmerCard not found");
        }

        if (monkCard != null)
        {
            monkCardName = monkCard.transform.Find("MonkCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("MonkCard not found");
        }

        // if for cats card here

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
                cookCardName.text = "Market (Cook)";
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
                gardenerCardName.text = "Market (Gardener)";
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

            if (dialogueScript.infoReceived_Wor)
            {
                workerCardName.text = "Castle Walls";
                workerCardImage.sprite = workerCardActivated;
                cardOpacity = workerCardImage.color;
                cardOpacity.a = 1f;
                workerCardImage.color = cardOpacity;
            }
            else
            {
                workerCardName.text = "???";
                cardOpacity = workerCardImage.color;
                cardOpacity.a = 0.5f;
                workerCardImage.color = cardOpacity;
            }

            if (dialogueScript.infoReceived_Far)
            {
                farmerCardName.text = "Farm";
                farmerCardImage.sprite = farmerCardActivated;
                cardOpacity = farmerCardImage.color;
                cardOpacity.a = 1f;
                farmerCardImage.color = cardOpacity;
            }
            else
            {
                farmerCardName.text = "???";
                cardOpacity = farmerCardImage.color;
                cardOpacity.a = 0.5f;
                farmerCardImage.color = cardOpacity;
            }

            if (dialogueScript.infoReceived_Mon)
            {
                monkCardName.text = "Shrine";
                monkCardImage.sprite = monkCardActivated;
                cardOpacity = monkCardImage.color;
                cardOpacity.a = 1f;
                monkCardImage.color = cardOpacity;
            }
            else
            {
                monkCardName.text = "???";
                cardOpacity = monkCardImage.color;
                cardOpacity.a = 0.5f;
                monkCardImage.color = cardOpacity;
            }

            // if for cats card here

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
                    cardInfoText.text = "Among all the other sellers in the market is the cook, who whips up meals for the citizens per request, making sure to use his skills as well as local ingredients to keep them well fed and satisfied. He often uses a cauldron to make his famous soups, which are ideal for the colder months. But when it's warmer outside, he's usually busy with his mortar.";
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
                    cardInfoText.text = "On most days one can find the castropolis' gardener at the market, where she sells a big variety of fresh herbs that can be used both for cooking and for medicinal purposes. Her garden is located near the market as well.";
                }
                else
                {
                    Debug.Log("Card is not unlocked yet");
                }
                break;

            case "Worker":
                if (dialogueScript.infoReceived_Wor && !infoActive)
                {
                    Debug.Log("Worker card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "The castle was originally a relatively small one and had no walls, with only a few knights protecting it. But after the Great War, in which the castropolis was almost taken over, the need for proper defence became apparent. The workers work tirelessly to make sure the walls are strong.";
                }  
                else
                {
                   Debug.Log("Card is not unlocked yet");
                }   
                break;

            case "Farmer":
                if (dialogueScript.infoReceived_Far && !infoActive)
                {
                    Debug.Log("Farmer card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "The farm offers fresh vegetables and fruit, as well as animal products of great quality to the citizens of the castropolis. The animals there are particularly friendly.";
                }  
                else
                {
                   Debug.Log("Card is not unlocked yet");
                }   
                break;

            case "Monk":
                if (dialogueScript.infoReceived_Mon && !infoActive)
                {
                    Debug.Log("Monk card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "The shrine is a place that welcomes any citizens that in need of finding calmness and inner peace. The monk can help guide them and give advice, as well as wisdom. The statue of Goddess Avena stands at the top of the little hill, blessing the castropolis with success in agriculture. If one talks to Goddess Avena, she might just share her wisdom.";
                }  
                else
                {
                   Debug.Log("Card is not unlocked yet");
                }   
                break;

            // case for cats here

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
