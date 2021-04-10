using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    private int Dir = 0;
    [SerializeField] private float Speed = 0f;
    private float LeftBorder = 0.0f;
    private float RightBorder = 0.0f;

    private void Start()
    {
        Dir = Random.Range(0, 2);
        LeftBorder = Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x /*+ 0.3f*/;
        RightBorder = -Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x/* - 0.3f*/;
        if(Speed == 0.0f)
        {
            Speed = Random.Range(1.5f, 5.0f);
        }
    }

    private void Update()
    {
        MovementLogic();
        CheckDir();
    }

    private void MovementLogic()
    {
        if (this.transform.position.x > LeftBorder && Dir == 0)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }
        else if (this.transform.position.x < RightBorder && Dir == 1)
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
    }

    private void CheckDir()
    {
        if (this.transform.position.x <= LeftBorder && Dir == 0) Dir = 1;
        else if (this.transform.position.x >= RightBorder && Dir == 1) Dir = 0;
    }
}
