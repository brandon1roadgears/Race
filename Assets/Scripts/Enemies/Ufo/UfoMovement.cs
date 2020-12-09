using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    private int Dir = 0;
    private float UfoSpeed = 0f;

    private void Start()
    {
        Dir = Random.Range(0, 2);
        UfoSpeed = Random.Range(3f, 7f);
    }

    private void FixedUpdate()
    {
        MovementLogic();
        CheckDir();
    }

    private void MovementLogic()
    {
        if (this.transform.position.x > -7.2f && Dir == 0)
        {
            this.transform.Translate(Vector2.left * Time.fixedDeltaTime * UfoSpeed);
        }
        else if (this.transform.position.x < 3.82f && Dir == 1)
        {
            this.transform.Translate(Vector2.right * Time.fixedDeltaTime * UfoSpeed);
        }
    }

    private void CheckDir()
    {
        if (this.transform.position.x <= -7.2f && Dir == 0) Dir = 1;
        else if (this.transform.position.x >= 3.82f && Dir == 1) Dir = 0;
    }
}
