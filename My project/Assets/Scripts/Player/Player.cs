using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerCoins))]
[RequireComponent(typeof(MovementBase))]
public class Player : MonoBehaviour
{
    private PlayerHealth m_Health;
    private PlayerCoins m_Coins;
    private float m_DamageCooldown = 0;
    private SpriteRenderer m_SR;

    private void Start()
    {
        m_Health = GetComponent<PlayerHealth>();
        m_Coins = GetComponent<PlayerCoins>();
        m_SR = GetComponent<SpriteRenderer>();
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
            CollectCoin(col.gameObject);
        } else if (col.gameObject.tag == "Damage")
        {
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            CollectCoin(other.gameObject);
        } else if (other.gameObject.tag == "Damage")
        {
            TakeDamage();
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

    private IEnumerator FlashRedOnDamage() {
        m_SR.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(GlobalSettings.FlashRedDuration);
        m_SR.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(GlobalSettings.FlashRedDuration);
        m_SR.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(GlobalSettings.FlashRedDuration);
        m_SR.color = new Color(1, 1, 1, 1);
    }

    private void TakeDamage()
    {
        if (m_DamageCooldown <= 0) 
        {
            m_Health.TakeDamage(GlobalSettings.Damage);
            m_DamageCooldown = GlobalSettings.PlayerDamageCooldown;
            if (m_SR != null)
                StartCoroutine(FlashRedOnDamage());
        }
    }

    private void CollectCoin(GameObject coin)
    {
        m_Coins.IncreaseCoinCount(1);
        Destroy(coin);
    }
}