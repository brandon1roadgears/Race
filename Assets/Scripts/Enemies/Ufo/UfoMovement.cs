using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    private float radius = 6f;
    private float CenterX = -2f ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector2(radius * Mathf.Cos(Time.time) + CenterX, this.transform.position.y);
    }
}
