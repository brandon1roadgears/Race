using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    private Animator DesAnim = null;

    private void Start()
    {
        DesAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Destroy(this.gameObject, DesAnim.GetCurrentAnimatorClipInfo(0).Length - 0.4f);
    }
}
