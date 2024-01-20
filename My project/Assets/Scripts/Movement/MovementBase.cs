using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    [Header("Aboveground Assistance")]
    [SerializeField] private float m_MaxYOffset;
    protected Vector3 m_StartingPosition;
    protected Quaternion m_StartingRotation;

    private void Update()
    {
        if (transform.position.y < m_StartingPosition.y - m_MaxYOffset)
            Reset();
    }

    private void Awake()
    {
        m_StartingPosition = transform.position;
        m_StartingRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected abstract void Move();

    private void Reset()
    {
        transform.position = m_StartingPosition;
        transform.rotation = m_StartingRotation;
        GlobalEvents.Player.PlayerRepositionEvent?.Invoke();
    }
}