using UnityEngine;
using TMPro;
public class UI_ResetIndicator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private Color m_OriginalColor;

    private Color m_FadeColor;
    private float m_FadeCooldown;

    private void Start()
    {
        m_FadeColor = new Color(m_OriginalColor.r, m_OriginalColor.g, m_OriginalColor.b, 0);
        m_Text.color = m_FadeColor;
    }

    private void Awake()
    {
        GlobalEvents.Player.PlayerRepositionEvent += ResetFade;
    }

    private void Update()
    {
        if (m_FadeCooldown > 0)
            m_FadeCooldown -= Time.deltaTime;

        m_Text.color = Color.Lerp(m_FadeColor, m_OriginalColor, (float) m_FadeCooldown / GlobalSettings.FadeCooldown);
        
    }

    private void OnDestroy()
    {
        GlobalEvents.Player.PlayerRepositionEvent -= ResetFade;
    }

    private void ResetFade()
    {
        m_Text.color = m_OriginalColor;
        m_FadeCooldown = GlobalSettings.FadeCooldown;
    }
}