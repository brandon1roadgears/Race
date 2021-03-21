using UnityEngine;

public class PlayerAction : MonoBehaviour
{ 
    internal Transform MainHandle = null;
    private float playerSpeed = 5f;
    private float LeftBorder = -3.26f, RightBorder = 3.26f;
    private bool IsMovingLeft = false;
    private bool IsMovingRight = false;

    private void Awake()
    {
        LeftBorder = Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x + 0.1f;
        RightBorder = -Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x - 0.1f;
        if(!MainHandle) MainHandle = GetComponent<Transform>();
    }

    private void Update()
    {
        if((MainHandle.localPosition.x <= -40 || IsMovingLeft) && this.transform.position.x > LeftBorder)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }

        if((MainHandle.localPosition.x >= 40 || IsMovingRight) && this.transform.position.x < RightBorder)
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
