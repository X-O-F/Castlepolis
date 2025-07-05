using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InteractableItem
{
    public GameObject item;
    public float respawnDelay = 2f;
    public int itemID; // Add an ID to map to Inventory items
}

public class ItemInteractionManager : MonoBehaviour
{
    [SerializeField] private List<InteractableItem> interactableItems = new List<InteractableItem>();
    [SerializeField] private GameObject interactionPopup; // UI Popup (E Icon + Text)

    private Dictionary<GameObject, InteractableItem> itemData = new Dictionary<GameObject, InteractableItem>();

    private bool isNearItem = false;
    private PlayerMovement playerMovement;
    private GameObject currentItem;



    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        // Populate dictionary from the inspector list
        foreach (var interactable in interactableItems)
        {
            if (interactable.item != null)
            {
                itemData[interactable.item] = interactable;
            }
        }

        if (interactionPopup != null)
        {
            interactionPopup.SetActive(false); // Hide popup at the start
        }
    }

    private void Update()
    {
        if (isNearItem && Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            PickupItem(currentItem);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UseSelectedItem();
        }
    }

    private void PickupItem(GameObject item)
    {
        if (item != null)
        {
            if (itemData.TryGetValue(item, out InteractableItem interactable))
            {
                Debug.Log("Attempting to pick up item with ID: " + interactable.itemID); // Add debug
                Item itemToAdd = DemoScript.instance.itemsToPickup[interactable.itemID];
                itemToAdd.itemID = interactable.itemID;

                bool added = false;

                if (itemToAdd.itemID == 2)
                {
                    added = InventoryManager.instance.AddItem(itemToAdd);
                    InventoryManager.instance.AddItem(itemToAdd);
                    InventoryManager.instance.AddItem(itemToAdd);
                }
                else
                {
                    added = InventoryManager.instance.AddItem(itemToAdd);
                }

                if (added)
                {
                    string itemName = getItemNameByID(itemToAdd.itemID);
                    if (itemName != null)
                        NotificationManager.instance.ShowNotif("Item Received:\n" + itemName, "item");
                    Debug.Log("Picked up item and added to inventory.");
                    Destroy(item);
                    interactionPopup.SetActive(false);
                    //StartCoroutine(RespawnItem(item, interactable.respawnDelay));
                }
                else
                {
                    NotificationManager.instance.ShowNotif("Error:\nInventory Full", "error");
                    Debug.Log("Inventory Full. Cannot pick up item.");
                }
            }
        }
    }


    private void UseSelectedItem()
    {
        Item usedItem = InventoryManager.instance.GetSelectedItem(true);
        if (usedItem != null)
        {
            Debug.Log("Used item: " + usedItem.name);

            if (usedItem.itemID == 0) // ← 0 is sword's ID from the Inspector
            {
                playerMovement.SwingSword();
            }
            else if (usedItem.itemID == 1) // 1 is pickaxe ID
            {
                playerMovement.SwingPickaxe();
            }
        }
        else
        {
            Debug.Log("No item to use.");
        }
    }
    private IEnumerator RespawnItem(GameObject item, float delay)
    {
        yield return new WaitForSeconds(delay);
        item.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Add this line for debugging
        if (itemData.ContainsKey(other.gameObject))
        {
            isNearItem = true;
            currentItem = other.gameObject;

            if (interactionPopup != null)
            {
                interactionPopup.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentItem == other.gameObject)
        {
            isNearItem = false;
            currentItem = null;

            if (interactionPopup != null)
            {
                interactionPopup.SetActive(false);
            }
        }
    }

    private string getItemNameByID(int id)
    {
        switch (id)
        {
            case 0:
                return "Sword";
            case 1:
                return "Pickaxe";
            case 2:
                return "Egg";
            case 3:
                return "Pepper";
            case 4:
                return "Carrot";
            case 5:
                return "Pumpkin";
            case 6:
                return "Potato";
            case 7:
                return "Avena Charms";
            case 8:
                return "Avena Charms";
            case 9:
                return "Avena Charms";
        }
        return null;
    }
}
