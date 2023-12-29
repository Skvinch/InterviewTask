using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance;
    
    [SerializeField] private int _coins;
    [SerializeField] private int _startingAmountOfCoins;
    [SerializeField] private TextMeshProUGUI _coinTxt;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start() => AddCoins(_startingAmountOfCoins);
    
    public void AddCoins(int amount)
    {
        _coins += amount;
        UpdateCoinTextValue();
    }
    
    public void RemoveCoins(int amount)
    {
        _coins -= amount;
        if (_coins < 0) _coins = 0;
        
        UpdateCoinTextValue();
    }
    
    public bool CanAffordItem(int amount) => _coins >= amount;
    
    private void UpdateCoinTextValue() => _coinTxt.text = _coins.ToString();
    
}
