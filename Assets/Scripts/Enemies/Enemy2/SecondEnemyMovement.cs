using UnityEngine;
using System.Collections;

public class SecondEnemyMovement : MonoBehaviour
{
    float WaitingTime = 1.0f;
    private bool IsMoving = true;
    private float MoveDir = 0.0f;
    private float [] Rnd = {-1.5f, 1.5f};
    private Camera Cam = null;

    private void Start()
    {
        Cam = Camera.main;
        float LeftBorder = Cam.ScreenToWorldPoint(Cam.transform.position).x;
        float RightBorder = -Cam.ScreenToWorldPoint(Cam.transform.position).x;
        MoveDir = Rnd[Mathf.RoundToInt(Random.Range(0, 2))];

        if (LeftBorder >= transform.position.x + MoveDir || RightBorder <= transform.position.x + MoveDir) 
        {
            MoveDir = MoveDir * -1;   
        }
        
    }

    private void Update()
    {
        if (IsMoving)
        {
            IsMoving = false;
            StartCoroutine(MoveEnemy2Logic());
        }
    }

    private IEnumerator MoveEnemy2Logic()
    {
        yield return new WaitForSeconds(WaitingTime);
        this.transform.position = new Vector2(this.transform.position.x + MoveDir, this.transform.position.y);
        MoveDir = -MoveDir;
        IsMoving = true;
    }
}
