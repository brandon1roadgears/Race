using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    private SpawnBlocks _SpawnBlocks = null;
    private float Speed = 0.05f;
    
    void Start()
    {
        _SpawnBlocks = this.GetComponent<SpawnBlocks>();
    }

    void Update()
    {
        if(this.transform.position.x > 0)
        {
            GoToCenter();
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsInGuardMod", true);
            _SpawnBlocks.enabled = true;
            this.transform.position = new Vector2(0.0f, this.transform.position.y);
            this.enabled = false;
        }
    }

    private void GoToCenter()
    {
        this.transform.Translate(Vector2.left * Speed);
    }
}
