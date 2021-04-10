using UnityEngine;
using System.Collections;

public class RoboMovement : MonoBehaviour
{
    private bool IsCorner = true;
    private int CurrentCorner = 0;
    private Vector2[] RoboCorners = new Vector2[4]
    {
        new Vector2(-0.8f, 0.0f), new Vector2(0.0f, -0.8f), new Vector2(0.8f, 0.0f), new Vector2(0.0f, 0.8f)
    };

    private void Update()
    {
        if(IsCorner)
        {
            IsCorner = false;
            StartCoroutine(NextCorner());
        }
    }

    private IEnumerator NextCorner()
    {
        yield return new WaitForSeconds(0.6f);
        this.transform.position = new Vector2(this.transform.position.x + RoboCorners[CurrentCorner].x, this.transform.position.y + RoboCorners[CurrentCorner].y);
        ++CurrentCorner;
        if(CurrentCorner == 4)
        {
            CurrentCorner = 0;
        }
        IsCorner = true;
    }
}
