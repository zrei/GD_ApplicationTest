using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
class PlayerMovement3d : MonoBehaviour
{
    private Rigidbody m_Sr;

    private void Start()
    {
        m_Sr = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move3D = new Vector3(move.x, 0, move.y);
        m_Sr.MovePosition(transform.position + move3D * GlobalSettings.Velocity * Time.fixedDeltaTime);
        
        if (move3D != Vector3.zero)
            m_Sr.transform.forward = move3D;
    }
}