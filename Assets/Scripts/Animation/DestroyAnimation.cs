using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    public void DestroyOnEnding()
    {
        Destroy(this.gameObject);
    }
}
