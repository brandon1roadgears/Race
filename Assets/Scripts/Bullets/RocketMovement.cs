using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private Transform LookAtObject = null;
    private float Speed = 4f;

    private void Update()
    {
        this.transform.Translate(Vector2.up * Time.deltaTime * Speed);
        if(LookAtObject != null)
        {
            this.transform.LookAt2D(this.transform.up, LookAtObject);
        }
    }

    internal Transform _LookAtObject
    {
        set {LookAtObject = value;}
    }
}
