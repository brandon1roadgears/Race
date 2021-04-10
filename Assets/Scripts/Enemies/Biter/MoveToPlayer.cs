using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{   
    private Transform Player = null;
    private int Dir = 0;
    private float Speed = 3f;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        Dir = this.transform.position.x < 0.0f ? 1 : -1; 
    }

    void Update()
    {
        if(this.transform.position.x > Player.transform.position.x - 0.2f && this.transform.position.x < Player.transform.position.x + 0.2f)
        {   
            this.transform.position = new Vector2(Player.position.x, Player.position.y + 0.3f);
        }
        else
        {
            this.transform.Translate(Vector2.right *  Dir * Speed * Time.deltaTime);
        }
    }
}
