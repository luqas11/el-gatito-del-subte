using System;
using UnityEngine;
using UnityEngine.UI;

public class StationReward : MonoBehaviour
{
    public Text coinText;
    public int coinAmount;

    const int MAX_COIN_PRIZE = 30;

    // Set coin amount for this reward indicator and return the given amount of coins
    public int setCoinValues(int time)
    {
        coinAmount = Math.Max(0, MAX_COIN_PRIZE - time);
        coinText.text = "+" + coinAmount;
        return coinAmount;
    }
}
