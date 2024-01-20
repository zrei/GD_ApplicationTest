using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int m_Health;
    private int m_MaxHealth;

    private void Awake()
    {
        if (GlobalSettings.IsReady)
            HandleDependencies();
        else
            GlobalSettings.OnReady += HandleDependencies;
        
    }

    private void HandleDependencies()
    {
        m_MaxHealth = GlobalSettings.PlayerHealth;
        ResetHealth();
        GlobalSettings.OnReady -= HandleDependencies;
    }

    public void ResetHealth()
    {
        m_Health = m_MaxHealth;
        GlobalEvents.UI.UpdateHealthBarEvent?.Invoke(Mathf.Max(0, (float) m_Health / m_MaxHealth));
    }

    public void TakeDamage(int damage)
    {
        m_Health -= damage;
        GlobalEvents.UI.UpdateHealthBarEvent?.Invoke(Mathf.Max(0, (float) m_Health / m_MaxHealth));
    }
}