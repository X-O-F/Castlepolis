using UnityEngine;
using System.Collections;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;
    public GameObject notificationPanel;
    public TextMeshProUGUI notificationText;

    private Coroutine notifCoroutine;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        notificationPanel.SetActive(false);
    }

    public void ShowNotif(string text, string type, int seconds = 4)
    {
        notificationText.text = text;

        if (type == "item")
            MusicManager.instance.PlayPopSFX();
        else if (type == "card")
            MusicManager.instance.PlayCardUnlockSFX();
        else if (type == "coin")
            MusicManager.instance.PlayCoinFoundSFX();
        else if (type == "error")
            MusicManager.instance.PlayErrorSFX();

        if (notifCoroutine != null)
            {
                StopCoroutine(notifCoroutine);
                notifCoroutine = null;
            }

        notifCoroutine = StartCoroutine(DisplayNotification(seconds));
    }

    private IEnumerator DisplayNotification(int seconds)
    {
        notificationPanel.SetActive(true);
        yield return new WaitForSeconds(seconds);
        notificationPanel.SetActive(false);
    }

}
