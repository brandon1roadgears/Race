using UnityEngine;

public class PlayerAction : MonoBehaviour
{    
    private float playerSpeed = 10f;
    private float LeftBorder = 0f, RightBorder = 0f;
    private bool IsMovingLeft = false;
    private bool IsMovingRight = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (IsMovingLeft && this.transform.position.x >= LeftBorder)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }

        if(IsMovingRight && this.transform.position.x <= RightBorder)
        {
            this.transform.Translate(Vector2.right * playerSpeed * Time.fixedDeltaTime);
        }
    }

    public void OnLeiftCklickDown()
    {
        IsMovingLeft = true;
    }

    public void OnRightCklickDown()
    {
        IsMovingRight = true;
    }

    public void OnLeiftCklickUp()
    {
        IsMovingLeft = false;
    }

    public void OnRightCklickUp()
    {
        IsMovingRight = false;
    }
}
