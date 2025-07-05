using UnityEngine;
using System.Collections;

public class ShopItemInteraction : MonoBehaviour
{
    public GameObject interactionPopup;
    public string npcName;
    public Item[] itemsForSale;
    public int price;

    public AudioClip hiClip;
    public AudioClip byeClip;
    public AudioClip thxClip;
    public AudioClip coinsClip;
    public AudioClip coinsSfxClip;

    public AudioSource audioSource;
    public AudioSource sfxSource;

    public string itemName;

    private bool playerNearby = false;

    public Dialogue dialogue;

    private bool lockedDialogue = false;
    private bool lastLine = false;


    void Awake()
    {
        dialogue = FindObjectOfType<Dialogue>(true);

        if (interactionPopup != null)
            interactionPopup.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (interactionPopup != null)
                interactionPopup.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (interactionPopup != null)
                interactionPopup.SetActive(false);
        }
    }

    void Update()
    {
        if (!dialogue) return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !lockedDialogue && !lastLine)
        {
            ShowBuyDialogue();
            interactionPopup.SetActive(false);
        }
        else if (playerNearby && Input.GetKeyDown(KeyCode.E) && lastLine && !lockedDialogue)
        {
            dialogue.ForceEndDialogueMode();
            lastLine = false;
            lockedDialogue = false;
        }
    }

    void ShowBuyDialogue()
    {
        string line = "";
        if (npcName == "sellerVeg")
        {
            line = "Hey there, I'm selling local vegetables. Would you like to buy?";
        }
        else if (npcName == "sellerAv")
        {
            line = "Greetings! I'm selling Avena Charms. Would you like to buy?";
        }
        else
        {
            Debug.Log("Shop error");
            return;
        }
        line += $" (Item: {itemName} Price: {price} coins.)";
        audioSource.clip = hiClip;
        audioSource.Play();
        lockedDialogue = true;
        dialogue.StartCustomDialogue(npcName, line, OnYes, OnNo);
    }

    void OnYes()
    {
        string line1 = "";
        if (npcName == "sellerVeg")
        {
            line1 = "Thanks for buying!";
        }
        else if (npcName == "sellerAv")
        {
            line1 = "Thanks for your purchase!";
        }
        else
        {
            Debug.Log("Shop error");
            return;
        }
        if (PlayerWallet.instance.SpendCoins(price))
        {
            foreach (Item item in itemsForSale)
            {
                InventoryManager.instance.AddItem(item);
            }
            audioSource.clip = thxClip;
            audioSource.Play();
            sfxSource.PlayOneShot(coinsSfxClip);
            dialogue.ShowLine(line1);
            lockedDialogue = false;
            lastLine = true;
        }
        else
        {
            audioSource.clip = coinsClip;
            audioSource.Play();
            dialogue.ShowLine("You don't have enough coins.");
            lockedDialogue = false;
            lastLine = true;
        }
    }
    void OnNo()
    {
        audioSource.clip = byeClip;
        audioSource.Play();
        dialogue.ShowLine("Come back any time!");
        lockedDialogue = false;
        lastLine = true;
    }
}
