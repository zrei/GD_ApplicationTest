using UnityEngine;

public class GlobalSettings : Singleton<GlobalSettings>
{
    [Header("Player Settings")]
    [SerializeField] private float m_Velocity = 1;
    public static float Velocity => Instance.m_Velocity;

    [SerializeField] private int m_PlayerHealth = 50;
    public static int PlayerHealth => Instance.m_PlayerHealth;

    [Header("Obstacle Settings")]
    [SerializeField] private int m_Damage = 2;
    public static int Damage => Instance.m_Damage;
}