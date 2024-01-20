using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UI_CoinCount : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text m_text;

    private void Start()
    {
        SetCoinText(0);
    }

    private void Awake()
    {
        GlobalEvents.UI.UpdateCoinCountEvent += SetCoinText;
    }

    private void OnDestroy()
    {
        GlobalEvents.UI.UpdateCoinCountEvent -= SetCoinText;
    }

    private void SetCoinText(int coinAmount)
    {
        m_text.text = "Coins: " + coinAmount;
    }
}