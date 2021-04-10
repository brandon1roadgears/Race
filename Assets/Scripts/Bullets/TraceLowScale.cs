using UnityEngine;

public class TraceLowScale : MonoBehaviour
{
    void Update()
    {
         this.transform.localScale = new Vector2(Mathf.Lerp(this.transform.localScale.x, 0.18f, 0.06f), Mathf.Lerp(this.transform.localScale.y, 0.18f, 0.02f));
         if(this.transform.localScale.x < 0.2f)
         {
             Destroy(this.gameObject);
         }
    }
}
