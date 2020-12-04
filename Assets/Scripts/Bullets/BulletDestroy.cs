using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    string[] Collisions = {"Border", "Enemy"};
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
