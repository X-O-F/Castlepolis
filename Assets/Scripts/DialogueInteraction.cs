using UnityEngine;

public class DialogueInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactionPopup; // UI Popup (E Icon + Text)
    public bool playerNearby = false;
    public Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dialogue = FindObjectOfType<Dialogue>(true);

        if (interactionPopup != null)
            interactionPopup.SetActive(false); // Hide popup at the start
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (interactionPopup != null)
                interactionPopup.SetActive(true); // Show popup when player is near
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if(interactionPopup != null)
                interactionPopup.SetActive(false); // Hide popup when player is away
        }
        if (dialogue != null && dialogue.dialogueActive)
        {
            dialogue.gameObject.SetActive(false);
            dialogue.dialogueActive = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue != null && !dialogue.dialogueActive)
            {
                dialogue.StartDialogue();
                if (interactionPopup != null)
                    interactionPopup.SetActive(false); // Hide popup when player interacted
            }
        }
        else if (playerNearby && dialogue != null && !dialogue.dialogueActive)
        {
            if (interactionPopup != null)
                interactionPopup.SetActive(true); // Show popup when dialogue ends but player is still near
        }
    }
}