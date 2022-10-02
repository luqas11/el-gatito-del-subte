using UnityEngine;
using UnityEngine.UI;

public class StationReward : MonoBehaviour
{
    public Text coinText;
    public int coinAmount;

    // Set coin amount for this reward indicator
    public void setCoinValues(int amount)
    {
        coinAmount = amount;
        coinText.text = coinAmount.ToString();
    }
}
