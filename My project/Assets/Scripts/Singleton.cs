using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance => m_Instance;
    private static T m_Instance = null;

    private void Awake()
    {
        if (m_Instance != null)
        {
            Debug.LogError("An instance already exists!");
            Destroy(this.gameObject);
            return;
        }

        m_Instance = (T) this;
    }

    private void OnDestroy()
    {
        if (m_Instance == this)
        {
            m_Instance = null;
        }
    }
}