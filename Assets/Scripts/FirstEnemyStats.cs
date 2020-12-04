using UnityEngine;

public class FirstEnemyStats : MonoBehaviour
{
    private short HealthPoint = 1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            --HealthPoint;
        }
        if (HealthPoint == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
