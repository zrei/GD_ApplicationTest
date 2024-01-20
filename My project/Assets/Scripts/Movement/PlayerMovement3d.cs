using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
class PlayerMovement3d : MovementBase
{
    private Rigidbody m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move3D = new Vector3(move.x, 0, move.y);
        m_rb.MovePosition(m_rb.position + move3D * GlobalSettings.Velocity * Time.fixedDeltaTime);
        
        if (move3D != Vector3.zero)
            m_rb.transform.forward = move3D;
    }
}