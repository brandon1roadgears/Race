using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private string[] Collisions = { "Border", "Enemy", "Player" };

    void Start()
    {
        
        if(this.gameObject.tag == "EnemyBullet")
        {
            Collisions[1] = "None";
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        foreach(string i in Collisions)
        {
            if(col.tag == i)
            {
                Destroy(this.gameObject);
                return;
            }
        }
    }
}
