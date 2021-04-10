using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private float Go, Out;
    
    void Update()
    {
        if(this.transform.position.x <= Go)
        {
            this.transform.position = new Vector2(Out, this.transform.position.y);
        }
        this.transform.Translate(Vector2.left * 2f * Time.deltaTime);
    }
    internal float _go
    {
        set {Go = value;}
    }
    internal float _out
    {
        set {Out = value;}
    }
}
