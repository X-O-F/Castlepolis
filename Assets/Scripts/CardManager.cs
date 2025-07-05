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

    public TextMeshProUGUI catCardName;
    public GameObject catCard;
    public Sprite catCardActivated;
    public Image catCardImage;


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

        if (catCard != null)
        {
            catCardName = catCard.transform.Find("CatCardName").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.Log("CatCard not found");
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
                InputManager.isGamePaused = true;

                Debug.Log("Menu is active");
                UpdateCardNames();
            }
            else if (cardsMenu != null && cardsActive)
            {
                MusicManager.instance.PlayPopSFX();
                CloseInfoMenu();
                CloseCardsMenu();
                InputManager.isGamePaused = false;
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
            cookCardName.text = "Cooking Tools";
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
            gardenerCardName.text = "Botanical Garden";
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
            workerCardName.text = "Castle Defense";
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
            farmerCardName.text = "Medieval Farming";
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
            monkCardName.text = "Goddess Avena";
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
            
        if (dialogueScript.infoReceived_Cat)
        {
            catCardName.text = "The Cat Legend";
            catCardImage.sprite = catCardActivated;
            cardOpacity = catCardImage.color;
            cardOpacity.a = 1f;
            catCardImage.color = cardOpacity;
        }
        else
        {
            catCardName.text = "???";
            cardOpacity = catCardImage.color;
            cardOpacity.a = 0.5f;
            catCardImage.color = cardOpacity;
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
                    cardInfoText.text = "Cooking Tools\n\nThe town's cook prepares meals using local ingredients and age-old techniques. His tools of choice include a large cauldron for hearty soups during the colder months, and a mortar and pestle for grinding herbs and spices in warmer seasons.";
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
                    cardInfoText.text = "Botanical Garden\n\nThe Garden of Castropolis holds a rich variety of flowers and fresh herbs, cherished by both cooks and healers. From thyme to sage, each plant serves a purpose—whether it’s flavoring a stew or easing a fever. You’ll find it near the market, a quiet green spot in the heart of the bustling town.";
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
                    cardInfoText.text = "Castle Defense\n\nThe castle was once a modest stronghold, without walls, guarded by only a handful of knights. But after the Great War —when Castropolis nearly fell— the need for true defenses became clear. Since then, workers have toiled day and night to raise sturdy walls, and more guards have been stationed to protect the town from enemies.";
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
                    cardInfoText.text = "Medieval Farming\n\nThe farm provides fresh vegetables, fruits, and high-quality animal products to the people of Castropolis. Animals like oxen and horses help plow the fields, while sheep supply wool and cows give milk. Traditional crop rotation and manure from the animals keep the soil rich, ensuring bountiful harvests year after year.";
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
                    cardInfoText.text = "Goddess Avena\n\nThe Shrine of Goddess Avena welcomes all who seek calm and inner peace. At the top of the hill stands Avena’s statue, watching over Castropolis and blessing its fields with growth. And if one dares speak to the Goddess… they may just hear her ancient wisdom whispered on the wind.";
                }
                else
                {
                    Debug.Log("Card is not unlocked yet");
                }
                break;
            case "Cat":
                if (dialogueScript.infoReceived_Cat && !infoActive)
                {
                    Debug.Log("Cat card clicked - presenting info");
                    cardInfo.SetActive(true);
                    cardsMenu.SetActive(false);
                    infoActive = true;
                    cardInfoText.text = "The Cat Legend\n\nLegend speaks of four lucky cats that roam these lands—each a guardian of fortune, courage, wisdom, and peace. If you are fortunate enough to meet all four, they say your luck will never run dry, your heart will stay brave, your mind forever sharp, and your spirit calm and steady.";
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
        InputManager.isGamePaused = false;
    }

    public void CloseInfoMenu()
    {
        cardInfo.SetActive(false);
        cardsMenu.SetActive(true);
        infoActive = false;
        Debug.Log("Closed CardInfo menu");
    }
}
