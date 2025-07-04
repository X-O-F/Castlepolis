using UnityEngine;

public class ShopItemInteraction : MonoBehaviour
{
    public GameObject interactionPopup;
    public string npcName;
    public Item itemForSale;
    public int price;

    public AudioClip hiClip;
    public AudioClip byeClip;
    public AudioClip thxClip;
    public AudioClip coinsClip;

    public AudioSource audioSource;

    public string itemName;

    private Dialogue dialogue;
    private bool playerNearby = false;

    void Awake()
    {
        dialogue = FindObjectOfType<Dialogue>(true);
        if(interactionPopup != null)
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
        if(other.CompareTag("Player"))
        {
            playerNearby = false;
            if (interactionPopup != null)
                interactionPopup.SetActive(false);
            dialogue.gameObject.SetActive(false);
            dialogue.dialogueActive = false;
        }
    }

    void Update()
    {
        if (!dialogue) return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowBuyDialogue();
            interactionPopup.SetActive(false);
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
            InventoryManager.instance.AddItem(itemForSale);
            audioSource.clip = thxClip;
            audioSource.Play();
            dialogue.ShowLine(line1);
        }
        else
        {
            audioSource.clip = coinsClip;
            audioSource.Play();
            dialogue.ShowLine("You don't have enough coins.");
        }
    }
    void OnNo()
    {
        audioSource.clip = byeClip;
        audioSource.Play();
        dialogue.ShowLine("Come back any time!");
    }
}
