using UnityEngine;

public class DialogueInteraction : MonoBehaviour
{
    public bool playerNearby = false;
    public Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dialogue = FindObjectOfType<Dialogue>(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
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
            }
        }
    }
}