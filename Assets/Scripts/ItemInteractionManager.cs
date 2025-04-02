using UnityEngine;

public class ItemInteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject sword; // Reference to the sword object in the world
    [SerializeField] private float interactionRange = 1f; // How close the player needs to be to interact with the object
    private bool isNearItem = false; // Tracks if the player is in range of an item
    private PlayerMovement playerMovement;
    
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isNearItem && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("is near and pressed e");
            InteractWithItem();
        }
    }

    private void InteractWithItem()
    {
        Debug.Log("interacting with sword");
        if (sword != null)
        {
            // Hide the sword (or make it inactive)
            sword.SetActive(false);

            // Lock the player's movement and trigger the sword swing animation
            playerMovement.SwingSword();

            // Optionally, you can implement logic here for picking up or interacting with other items
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("player near object");
        // Check if the player is near an interactable object (e.g., the sword)
        if (other.CompareTag("Interactable")) // Ensure your sword object has the "Interactable" tag
        {
            isNearItem = true;
            Debug.Log("Press E to interact with the sword.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player left object");
        // If the player moves away from the item, stop interaction
        if (other.CompareTag("Interactable"))
        {
            isNearItem = false;
        }
    }
}
