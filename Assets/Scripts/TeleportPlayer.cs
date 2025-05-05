using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player; // reference to your player object
    public Vector2 entrancePosition; // target position to teleport to
    public Vector2 farmPosition;
    public Vector2 marketPosition;
    public Vector2 castlePosition;

    // This function gets called from the button's OnClick event
    public void tpEntrance()
    {
        if(entrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = entrancePosition;
        Debug.Log("Player teleported to town entrance.");
    }

    public void tpFarm()
    {
        if(entrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = farmPosition;
        Debug.Log("Player teleported to farm.");
    }

    public void tpMarket()
    {
        if(entrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = marketPosition;
        Debug.Log("Player teleported to market.");
    }

    public void tpCastle()
    {
        if(entrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = castlePosition;
        Debug.Log("Player teleported to castle.");
    }
}
