using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    public void DestroyOnEnding()
    {
        Destroy(this.gameObject);
    }
    public void SetFalseToMultiplieAnimation()
    {
        this.GetComponent<Animator>().SetBool("isStartMuiltiplierAnimation", false);
    }
}
