using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private float playerSpeed = 10f;
    private float LeftBorder = 0f, RightBorder = 0f;

    private void Start()
    {
        switch (Camera.main.pixelWidth)
        {
            case 800:
                LeftBorder = -6.5f;
                RightBorder = 3.5f;
                break;

            case 1280:
                LeftBorder = -7.1f;
                RightBorder = 3.75f;
                break;

            case 1920:
                LeftBorder = -7.1f;
                RightBorder = 3.75f;
                break;

            case 2160:
                LeftBorder = -8.05f;
                RightBorder = 4.25f;
                break;

            case 2560:
                LeftBorder = -7.15f;
                RightBorder = 3.7f;
                break;

            case 2960:
                LeftBorder = -8.25f;
                RightBorder = 4.3f;
                break;
        }
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x >= LeftBorder)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) && this.transform.position.x < RightBorder)
        {
            this.transform.Translate(Vector2.right * playerSpeed * Time.fixedDeltaTime);
        }
    }
}
