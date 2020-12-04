using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
