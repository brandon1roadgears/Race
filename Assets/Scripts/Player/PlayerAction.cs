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
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.1f)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) && this.transform.position.x < 4.1f)
        {
            this.transform.Translate(Vector2.right * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
