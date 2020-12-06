using UnityEngine;

public class UfoMovement : MonoBehaviour
{
    private float radius = 6f;
    private float CenterX = -2f ;
   
    private void FixedUpdate()
    {
        this.transform.position = new Vector2(radius * Mathf.Cos(Time.time) + CenterX, this.transform.position.y);
    }
}
