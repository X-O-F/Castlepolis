using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinInteraction : MonoBehaviour
{
    public GameObject interactionPopup;
    public float respawnDelay = 60;
    public int coinValue = 100;
    private bool isNearCoin = false;

    // Update is called once per frame
    void Update()
    {
        if (isNearCoin && Input.GetKeyDown(KeyCode.E))
        {
            HideCoin();
            PlayerWallet.instance.AddCoins(coinValue);
            MusicManager.instance.PlayCoinFoundSFX();
            StartCoroutine(RespawnItem(respawnDelay));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);
        isNearCoin = true;
        if (interactionPopup != null)
        {
            interactionPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isNearCoin = false;
        if (interactionPopup != null)
        {
            interactionPopup.SetActive(false);
        }
    }


    private IEnumerator RespawnItem(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowCoin();
    }

    private void HideCoin()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void ShowCoin()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
