using UnityEngine;

public class PlayerAction : MonoBehaviour
{ 
    private float playerSpeed = 6f;
    private float LeftBorder = -3.26f, RightBorder = 3.26f;
    private bool IsMovingLeft = false;
    private bool IsMovingRight = false;
    

    private void Start()
    {
        switch(Camera.main.pixelWidth)
        {
            case 800:
                LeftBorder = -3.26f;
                RightBorder = 3.26f;
                break;
            
            case 1280:
                LeftBorder = -3.47f;
                RightBorder = 3.47f;
                break;

            case 1920:
                LeftBorder = -3.47f;
                RightBorder = 3.47f;
                break;

            case 2160:
                LeftBorder = -3.94f;
                RightBorder = 3.94f;
                break;
            
            case 2560:
                LeftBorder = -3.47f;
                RightBorder = 3.47f;
                break;

            case 2960:
                LeftBorder = -4.03f;
                RightBorder = 4.03f;
                break;
        }

    }

    private void Update()
    {
        if (IsMovingLeft && this.transform.position.x > LeftBorder)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }

        if(IsMovingRight && this.transform.position.x < RightBorder)
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
