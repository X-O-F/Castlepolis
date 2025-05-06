using UnityEngine;

public class ShopItemInteraction : MonoBehaviour
{
    public GameObject interactionPopup;
    public string npcName;
    public Item itemForSale;
    public int price;

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
        string line = $"This {itemName} costs {price} coins. Do you want to buy it?";
        dialogue.StartCustomDialogue(npcName, line, OnYes, OnNo);
    }

    void OnYes()
    {
        if(PlayerWallet.instance.SpendCoins(price))
        {
            InventoryManager.instance.AddItem(itemForSale);
            dialogue.ShowLine("Thanks for your purchase!");
        }
        else
        {
            dialogue.ShowLine("Sorry, you don't have enough coins.");
        }
    }
    void OnNo()
    {
        dialogue.ShowLine("Come back any time!");
    }
}
