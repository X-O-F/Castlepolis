using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerWallet : MonoBehaviour
{
   public static PlayerWallet instance;
   public int coins = 500;
   public TMP_Text coinText;

   private void Awake()
   {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
   }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
            return true;
        }
        return false; // Player does not have the coins required for the purchase.
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
    }
}
