using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    [SerializeField] private float EndingTime = 0.0f;
    private Animator DesAnim = null;

    private void Start()
    {
        DesAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Destroy(this.gameObject, DesAnim.GetCurrentAnimatorClipInfo(0).Length - EndingTime);
    }
}
