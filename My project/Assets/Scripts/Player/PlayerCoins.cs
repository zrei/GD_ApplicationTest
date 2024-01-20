using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    private int m_CoinCount = 0;

    private void Awake()
    {
        ResetCoinCount();
    }

    public void ResetCoinCount()
    {
        m_CoinCount = 0;
        GlobalEvents.UI.UpdateCoinCountEvent?.Invoke(m_CoinCount);
    }

    public void IncreaseCoinCount(int amount)
    {
        m_CoinCount += amount;
        GlobalEvents.UI.UpdateCoinCountEvent?.Invoke(m_CoinCount);
    }
}