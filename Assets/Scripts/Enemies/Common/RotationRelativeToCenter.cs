using UnityEngine;

public class RotationRelativeToCenter : MonoBehaviour
{    
    [SerializeField] private float Angle = 0.0f;
    [SerializeField] private Transform Center = null;
    [SerializeField] private float Radius = 0.7f;
    [SerializeField] private float SpeedRotation = 0.0f;
    private void Start()
    {
        if(SpeedRotation == 0.0f)
        {
            SpeedRotation = Random.Range(0.03f, 0.05f);
        }
        if(Center == null)
        {
            Center = this.GetComponent<Transform>();
            Center.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
    void Update()
    {
        this.transform.position = new Vector2(Radius * Mathf.Sin(Angle) + Center.position.x, Radius * Mathf.Cos(Angle) + Center.position.y);
        Angle += SpeedRotation;
    }
}
