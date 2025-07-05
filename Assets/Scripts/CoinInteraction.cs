using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinInteraction : MonoBehaviour
{
    public GameObject interactionPopup;
    public float respawnDelay = 60;
    public int coinValue = 100;

    public bool playerNearby = false;
    
    // Update is called once per frame
    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            HideCoin();
            PlayerWallet.instance.AddCoins(coinValue);
            NotificationManager.instance.ShowNotif("Coins found!\n+" + coinValue, "coin");
            StartCoroutine(RespawnItem(respawnDelay));
        }
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
    }


    private IEnumerator RespawnItem(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowCoin();
    }

    private void HideCoin()
    {
        playerNearby = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void ShowCoin()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
