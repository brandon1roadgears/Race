using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float playerSpeed = 10f;
    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
