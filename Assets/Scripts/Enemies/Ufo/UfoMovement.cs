using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    private int Dir = 0;
    private float UfoSpeed = 0f;
    private float LeftBorder =-3.04f;
    private float RightBorder = 2.46f;

    private void Start()
    {
        Dir = Random.Range(0, 2);
        UfoSpeed = Random.Range(1.5f, 5.5f);
    }

    private void FixedUpdate()
    {
        MovementLogic();
        CheckDir();
    }

    private void MovementLogic()
    {
        if (this.transform.position.x > LeftBorder && Dir == 0)
        {
            this.transform.Translate(Vector2.left * Time.fixedDeltaTime * UfoSpeed);
        }
        else if (this.transform.position.x < RightBorder && Dir == 1)
        {
            this.transform.Translate(Vector2.right * Time.fixedDeltaTime * UfoSpeed);
        }
    }

    private void CheckDir()
    {
        if (this.transform.position.x <= LeftBorder && Dir == 0) Dir = 1;
        else if (this.transform.position.x >= RightBorder && Dir == 1) Dir = 0;
    }
}
