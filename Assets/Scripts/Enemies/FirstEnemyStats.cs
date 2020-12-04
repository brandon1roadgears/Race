using UnityEngine;

public class FirstEnemyStats : MonoBehaviour
{
    private short HealthPoint = 1;
    private string[] Collisions = { "Bullet" };
    void OnTriggerEnter2D(Collider2D col)
    {
        foreach(string i in Collisions)
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
