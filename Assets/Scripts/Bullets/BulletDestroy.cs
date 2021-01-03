using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private string[] Collisions = null;

    private void Start()
    {
        if(this.gameObject.tag == "EnemyBullet")
        {
            Collisions = new string[] { "Player", "PlayerBullet", "Border"};
        }
        else if(this.gameObject.tag == "PlayerBullet")
        {
            Collisions = new string[] { "Enemy", "EnemyBullet", "Border" };
        }
    }

    private void OnTriggerExit2D(Collider2D col)
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
