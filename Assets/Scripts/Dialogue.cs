using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private DialogueInteraction currentInteraction;


    public void SetInteraction(DialogueInteraction interaction)
    {
        currentInteraction = interaction;
    }

    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public GameObject indicator;
    public bool dialogueActive = false;
    public bool infoReceived_Cook = false;
    public bool infoReceived_Gar = false;
    public bool infoReceived_Wor = false;
    public bool infoReceived_Far = false;
    public bool infoReceived_Mon = false;
    // infoReceived_Cats?
    public Button yesButton, noButton;
    public Item farmerItem;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

    private System.Action yesAction, noAction;

    private int index;

    [System.Serializable]
    public class npcDialogue
    {
        public string npcName;
        public string[] lines;
        public AudioClip[] audioClips;
    }

    public npcDialogue[] npcDialogues;
    private string[] current;
    private AudioClip[] currentAudio;

    public AudioSource audioSource;

    private string avenaLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        indicator.SetActive(false);
        SetVisible(false);
        textComponent.text = string.Empty;
    }

    void Update()
    {
        if (isTyping)
            indicator.SetActive(false);
        else
            indicator.SetActive(true);
    }

    public void SetVisible(bool visible)
    {
        if (visible)
        {
            GetComponent<CanvasGroup>().alpha = 1f;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().interactable = false;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }


    public void StartDialogue(string npcName)
    {
        StopAllCoroutines();

        textComponent.text = string.Empty;
        current = null;
        currentAudio = null;

        foreach (var npcDialogue in npcDialogues)
        {
            if (npcDialogue.npcName == npcName)
            {
                current = npcDialogue.lines;
                currentAudio = npcDialogue.audioClips;

                if (npcDialogue.npcName == "Cook")
                {
                    infoReceived_Cook = true;
                    NotificationManager.instance.ShowNotif("Card Unlocked:\nCook", "card");
                    Debug.Log("Info received from cook");
                }
                else if (npcDialogue.npcName == "Gardener")
                {
                    infoReceived_Gar = true;
                    NotificationManager.instance.ShowNotif("Card Unlocked:\nGardener", "card");
                    Debug.Log("Info received from gardener");
                }
                else if (npcDialogue.npcName == "Worker")
                {
                    infoReceived_Wor = true;
                    NotificationManager.instance.ShowNotif("Card Unlocked:\nWorker", "card");
                    Debug.Log("Info received from worker");
                }
                else if (npcDialogue.npcName == "Farmer")
                {
                    InventoryManager.instance.AddItem(farmerItem);
                    NotificationManager.instance.ShowNotif("Item Received:\nCarrot", "item");
                    Debug.Log("Farmer gave carrot to player.");
                }
                else if (npcDialogue.npcName == "Monk")
                {
                    infoReceived_Mon = true;
                    NotificationManager.instance.ShowNotif("Card Unlocked:\nMonk", "card");
                    Debug.Log("Info received from monk");
                }
                else if (npcDialogue.npcName == "Farmer2")
                {
                    infoReceived_Far = true;
                    NotificationManager.instance.ShowNotif("Card Unlocked:\nFarmer", "card");
                    Debug.Log("Info received from farmer");
                }
                else if (npcDialogue.npcName == "Avena")
                {
                    int randomIndex = Random.Range(0, npcDialogue.lines.Length);
                    avenaLine = npcDialogue.lines[randomIndex];
                    audioSource.clip = npcDialogue.audioClips[0];
                    current = new string[] { avenaLine };
                }

                break;

                // if for cats here -- set infoReceived_Cats = true;
            }
        }

        if (current == null || current.Length == 0)
        {
            Debug.Log("No dialogue found for NPC: {npcName}");
            return;
        }


        SetVisible(true);

        index = 0;
        dialogueActive = true;
        if (currentAudio[0] != null)
        {
            audioSource.clip = currentAudio[0];
            audioSource.Play();
        }

        typingCoroutine = StartCoroutine(TypeLine());
    }

    public void StartCustomDialogue(string npcName, string message, System.Action onYes, System.Action onNo)
    {
        dialogueActive = true;
        SetVisible(true);

        current = new string[] { message };
        StartCoroutine(TypeLine(true));

        yesAction = onYes;
        noAction = onNo;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => { yesAction?.Invoke(); HideOptions(); });
        noButton.onClick.AddListener(() => { noAction?.Invoke(); HideOptions(); });

        yesButton.gameObject.SetActive(false); // Hide until typing finishes
        noButton.gameObject.SetActive(false);
    }

    public void ShowLine(string message)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            isTyping = false;
        }

        current = new string[] { message };
        textComponent.text = string.Empty;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    void HideOptions()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    public IEnumerator TypeLine(bool isShop = false)
    {
        InputManager.isGamePaused = true; // Lock player movement during dialogue
        isTyping = true;
        textComponent.text = string.Empty;
        foreach (char c in current[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
        typingCoroutine = null;

        if (isShop == true)
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
            isShop = false;
        }
    }

    public void NextLine()
    {
        if (current == null) return;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            textComponent.text = current[index];
            typingCoroutine = null;
            isTyping = false;
            return;
        }

        if (index < current.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            if (currentAudio.Length > 1)
            {
                audioSource.clip = currentAudio[index];
                audioSource.Play();
            }
            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            audioSource.Stop();
            dialogueActive = false;
            SetVisible(false);
            InputManager.isGamePaused = false; // Unlock player movement
        }
    }

    public void ForceEndDialogueMode()
    {
        textComponent.text = string.Empty;
        audioSource.Stop();
        dialogueActive = false;
        SetVisible(false);
        InputManager.isGamePaused = false; // Unlock player movement
    }
}