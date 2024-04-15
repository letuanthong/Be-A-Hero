using System;
using UnityEngine;

public class CoinController : Singleton<CoinController>
{
    [SerializeField] private float coinTest;

    public float Coins { get; private set; }
    private const string COIN_KEY = "Coins";

    private void Start()
    {
        Coins = coinTest;
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }

    public void RemoveCoins(float amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
        }
    }
}