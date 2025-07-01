using System.Collections;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{

    [SerializeField] private GameObject interactionPopup; // UI Popup

    [SerializeField] private GameObject blackScreen;

    public TeleportPlayer teleportPlayer;
    [SerializeField] private string toArea;
    public bool playerNearby = false;

    void Awake()
    {
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
            if (interactionPopup != null)
                interactionPopup.SetActive(false); // Hide popup when player is away
        }
    }
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            switch (toArea)
            {
                case "castleInterior":
                    MusicManager.instance.PlayDoorOpenSFX();
                    teleportPlayer.tpCastleInterior();
                    StartCoroutine(showBlackScreen());;
                    MusicManager.instance.PlayCastleMusic();
                    break;
                case "castleEntrance":
                    MusicManager.instance.PlayDoorCloseSFX();
                    teleportPlayer.tpCastleEntrance();
                    StartCoroutine(showBlackScreen());
                    MusicManager.instance.PlayTownMusic();
                    break;
                default:
                    Debug.Log("Wrong teleport area specified for teleport trigger");
                    break;
            }
        }
        else if (playerNearby)
        {
            if (interactionPopup != null)
                interactionPopup.SetActive(true);
        }
    }

    IEnumerator showBlackScreen()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        blackScreen.SetActive(false);
    }
}
