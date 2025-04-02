using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InteractableItem
{
    public GameObject item;
    public float respawnDelay = 2f;
}

public class ItemInteractionManager : MonoBehaviour
{
    [SerializeField] private List<InteractableItem> interactableItems = new List<InteractableItem>();
    private Dictionary<GameObject, float> itemDelays = new Dictionary<GameObject, float>();

    private bool isNearItem = false;
    private PlayerMovement playerMovement;
    private GameObject currentItem;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        // Populate dictionary from the inspector list
        foreach (var item in interactableItems)
        {
            if (item.item != null)
            {
                itemDelays[item.item] = item.respawnDelay;
            }
        }
    }

    private void Update()
    {
        if (isNearItem && Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            InteractWithItem(currentItem);
        }
    }

    private void InteractWithItem(GameObject item)
    {
        if (item != null)
        {
            item.SetActive(false);
            playerMovement.SwingSword();

            float delay = itemDelays.ContainsKey(item) ? itemDelays[item] : 2f;
            StartCoroutine(RespawnItem(item, delay));
        }
    }

    private IEnumerator RespawnItem(GameObject item, float delay)
    {
        yield return new WaitForSeconds(delay);
        item.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (itemDelays.ContainsKey(other.gameObject)) // Check if it's a registered interactable item
        {
            isNearItem = true;
            currentItem = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (currentItem == other.gameObject)
        {
            isNearItem = false;
            currentItem = null;
        }
    }
}
