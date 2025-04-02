using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool _playerNearby;
    private GameObject _player;

    void Update()
    {
        if (_playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed near sword");
            StartCoroutine(PickUpSword());
        }       
    }

    private IEnumerator PickUpSword()
    {
        _player.GetComponent<PlayerMovement>().SwingSword();
        gameObject.SetActive(false);

        Debug.Log("hidden sword");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("reappearing sword after delay");

        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerNearby = true;
            _player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerNearby = false;
            _player = null;
        }
    }
}
