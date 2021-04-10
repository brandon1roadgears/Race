using UnityEngine;
using System.Collections;

public class ShrederMove : MonoBehaviour
{
    private Transform PlayerPosition = null;
    private float Speed = 3f;
    private bool StopTarget = false;
    private void Start()
    {
        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(StopLookOnPlayer());
    }

    private void Update()
    {
        this.transform.Translate(-Vector2.up * Speed * Time.deltaTime);
        if(!StopTarget)
        {
            this.transform.LookAt2D(-this.transform.up, PlayerPosition);
        }
    }
    private IEnumerator StopLookOnPlayer()
    {
        yield return new WaitForSeconds(1.6f);
        StopTarget = true;
        GetComponent<Animator>().SetBool("InTargetPhase", true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
