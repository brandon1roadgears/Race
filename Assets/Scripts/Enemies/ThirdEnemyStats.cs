using UnityEngine;

public class ThirdEnemyStats : MonoBehaviour
{
    private short HealthPoint = 3;
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
