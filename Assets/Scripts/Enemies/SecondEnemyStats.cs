using UnityEngine;

public class SecondEnemyStats : MonoBehaviour
{
    private short HealthPoint = 2;
    private string[] Collisions = { "Bullet" };
    void OnTriggerEnter2D(Collider2D col)
    {
        foreach (string i in Collisions)
        {
            if (col.tag == "Bullet")
            {
                --HealthPoint;
            }
        }
        if (HealthPoint == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
