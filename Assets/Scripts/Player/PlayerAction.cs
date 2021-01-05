using UnityEngine;

public class PlayerAction : MonoBehaviour
{ 
    [SerializeField] private GameObject Handle = null;
    private float playerSpeed = 6f;
    private float LeftBorder = -3.26f, RightBorder = 3.26f;
    private bool IsMovingLeft = false;
    private bool IsMovingRight = false;
    private Camera Cam;

    private ButtonEvent ButEv = null;

    private void Start()
    {
        Cam = Camera.main;
        LeftBorder = Cam.ScreenToWorldPoint(Cam.transform.position).x + 0.1f;
        RightBorder = -Cam.ScreenToWorldPoint(Cam.transform.position).x - 0.1f;
        ButEv = GameObject.Find("Canvas").GetComponent<ButtonEvent>();
    }

    private void Update()
    {
        if((Handle.transform.localPosition.x < 0 || IsMovingLeft) && this.transform.position.x > LeftBorder)
        {
            this.transform.Translate(Vector2.left * playerSpeed * Time.fixedDeltaTime);
        }

        if((Handle.transform.localPosition.x > 0 || IsMovingRight) && this.transform.position.x < RightBorder)
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
