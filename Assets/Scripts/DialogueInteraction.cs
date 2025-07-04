using UnityEngine;

public class DialogueInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactionPopup; // UI Popup (E Icon + Text)
    public bool playerNearby = false;
    public Dialogue dialogue;

    public string npcName;

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

        /*if (dialogue != null && dialogue.dialogueActive)
        {
            dialogue.SetVisible(false);
            dialogue.dialogueActive = false;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogue) return;

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogue.dialogueActive)
            {
                dialogue.SetInteraction(this);
                dialogue.StartDialogue(npcName);
                if (interactionPopup != null)
                    interactionPopup.SetActive(false);
            }
            else
            {
                dialogue.NextLine();
            }
        }
        else if (playerNearby && !dialogue.dialogueActive)
        {
            if (interactionPopup != null)
                interactionPopup.SetActive(true);
        }
    }

}