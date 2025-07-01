using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player; // reference to your player object
    public Vector2 entrancePosition; // target position to teleport to
    public Vector2 farmPosition;
    public Vector2 marketPosition;
    public Vector2 shrinePosition;
    public Vector2 castlePosition;
    public Vector2 parkPosition;
    public Vector2 castleEntrancePosition;
    public Vector2 castleInteriorPosition;

    // This function gets called from the button's OnClick event
    public void tpEntrance()
    {
        if (entrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = entrancePosition;
        Debug.Log("Player teleported to town entrance.");
    }

    public void tpFarm()
    {
        if (farmPosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = farmPosition;
        Debug.Log("Player teleported to farm.");
    }

    public void tpMarket()
    {
        if (marketPosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = marketPosition;
        Debug.Log("Player teleported to market.");
    }

    public void tpShrine()
    {
        if (shrinePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = shrinePosition;
        Debug.Log("Player teleported to shrine.");
    }

    public void tpCastle()
    {
        if (castlePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = castlePosition;
        Debug.Log("Player teleported to castle.");
    }

    public void tpPark()
    {
        if (parkPosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = parkPosition;
        Debug.Log("Player teleported to park.");
    }

    public void tpCastleInterior()
    {
        if (castleInteriorPosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = castleInteriorPosition;
        Debug.Log("Player teleported to castle interior.");
    }
    
    public void tpCastleEntrance()
    {
        if(castleEntrancePosition == null || player == null)
        {
            Debug.Log("Error: teleport position not specified or player object not linked");
            return;
        }
        player.position = castleEntrancePosition;
        Debug.Log("Player teleported to castle entrance.");
    }
}

