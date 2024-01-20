using UnityEngine;

public class GlobalSettings : Singleton<GlobalSettings>
{
    [Header("Player Settings")]
    [SerializeField] private float m_Velocity = 1;
    public static float Velocity => Instance.m_Velocity;
    [SerializeField] private float m_JumpVelocity = 1;
    public static float JumpVelocity => Instance.m_JumpVelocity;
    [SerializeField] private float m_PlayerDamageCooldown = 2;
    public static float PlayerDamageCooldown => Instance.m_PlayerDamageCooldown;
    [SerializeField] private float m_FlashRedDuration = 0.15f;
    public static float FlashRedDuration => Instance.m_FlashRedDuration;
    [SerializeField] private int m_PlayerHealth = 50;
    public static int PlayerHealth => Instance.m_PlayerHealth;

    [Header("Obstacle Settings")]
    [SerializeField] private int m_Damage = 2;
    public static int Damage => Instance.m_Damage;

    [Header("UI Settings")]
    [SerializeField] private float m_FadeCooldown = 2;
    public static float FadeCooldown => Instance.m_FadeCooldown;
}