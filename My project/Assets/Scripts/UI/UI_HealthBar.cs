using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider m_Slider;
    
    private void Start()
    {
        UpdateFill(1);
    }

    private void Awake()
    {
        GlobalEvents.UI.UpdateHealthBarEvent += UpdateFill;
    }

    private void OnDestroy()
    {
        GlobalEvents.UI.UpdateHealthBarEvent -= UpdateFill;
    }

    private void UpdateFill(float fill)
    {
        if (fill < 0 || fill > 1)
        {
            Debug.LogError("Invalid health bar fill amount.");
            return;
        }
        m_Slider.value = fill;
    }
}