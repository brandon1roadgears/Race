using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float playerSpeed = 0.4f;
    private Rigidbody2D rb;
    
    private Vector2 movementVector
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            return new Vector2(horizontal, 0f);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb.AddForce(movementVector * playerSpeed, ForceMode2D.Impulse);
    }
}
