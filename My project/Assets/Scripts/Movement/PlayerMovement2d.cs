using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
class PlayerMovement2d : MovementBase
{
    [Header("Grounding Assistance")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D m_rb;
    private BoxCollider2D m_BoxCollider;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void Move()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        m_rb.velocity = new Vector2(direction * GlobalSettings.Velocity, m_rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            m_rb.velocity = new Vector2(m_rb.velocity.x, GlobalSettings.JumpVelocity);
        }

        if (direction > 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0f);
        else if (direction < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0f);
    }

    private bool IsGrounded() {
        Bounds bounds = m_BoxCollider.bounds;
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(bounds.min.x, bounds.min.y), Vector2.down, 0.02f, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(bounds.max.x, bounds.min.y), Vector2.down, 0.02f, groundLayer);

        bool isGrounded = hitLeft || hitRight;
        return isGrounded;
    }
}