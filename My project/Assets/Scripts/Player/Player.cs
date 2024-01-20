using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerCoins))]
public class Player : MonoBehaviour
{
    private PlayerHealth m_Health;
    private PlayerCoins m_Coins;
    private float m_DamageCooldown = 0;
    
    private void Start()
    {
        m_Health = GetComponent<PlayerHealth>();
        m_Coins = GetComponent<PlayerCoins>();
    }

    private void Awake()
    {
        GlobalEvents.Player.PlayerDeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        GlobalEvents.Player.PlayerDeathEvent -= OnDeath;
    }

    private void Update()
    {
        if (m_DamageCooldown > 0)
            m_DamageCooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            m_Coins.IncreaseCoinCount(1);
            Destroy(col.gameObject);
        } else if (col.gameObject.tag == "Damage")
        {
            if (m_DamageCooldown <= 0) 
            {
                m_Health.TakeDamage(GlobalSettings.Damage);
                m_DamageCooldown = GlobalSettings.PlayerDamageCooldown;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            m_Coins.IncreaseCoinCount(1);
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "Damage")
        {
            if (m_DamageCooldown <= 0) 
            {
                m_Health.TakeDamage(GlobalSettings.Damage);
                m_DamageCooldown = GlobalSettings.PlayerDamageCooldown;
            }
        }
    }

    private void Reset()
    {
        m_Health.ResetHealth();
        m_Coins.ResetCoinCount();
    }

    private void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}