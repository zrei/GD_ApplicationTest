using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class PlayerMovement2d : MonoBehaviour
{
    private Rigidbody2D m_Sr;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D m_BoxCollider;
    private float m_JumpDuration;

    private void Start()
    {
        m_Sr = GetComponent<Rigidbody2D>();
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        m_Sr.velocity = new Vector2(direction * GlobalSettings.Velocity, m_Sr.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            m_Sr.velocity = new Vector2(m_Sr.velocity.x, GlobalSettings.JumpVelocity);
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