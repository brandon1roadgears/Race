using UnityEngine;
using System.Collections;

public class AutoTargetLogic : MonoBehaviour
{   
    [SerializeField] private GameObject Rocket = null;
    private Transform Player = null;
    private Animator _Animator = null;
    private bool IsStopTarge = false;
    private Vector2[] RocketPositions = new Vector2[6]
    {
        new Vector2(-7.8f, 0.38f), new Vector2(7.8f, 0.38f), new Vector2(-5.8f, 4.15f),
        new Vector2(5.8f, 4.15f), new Vector2(-2f, 4.15f), new Vector2(2f, 4.15f),
    };

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        _Animator = this.GetComponent<Animator>();
        StartCoroutine(StopTarget(3f));
        StartCoroutine(Fire(4.5f));
        StartCoroutine(DeleteTarget(8f));
    }
    private void Update()
    {
        if(!IsStopTarge)
        {
            this.transform.position = Player.transform.position;
        }
    }

    private IEnumerator StopTarget(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        _Animator.SetBool("IsAutoFirePhase", true);
        IsStopTarge = true;
    }
    private IEnumerator Fire(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        for(int i = 0; i < 6; ++i)
        {
            Instantiate(Rocket, RocketPositions[i], this.transform.rotation).GetComponent<RocketMovement>()._LookAtObject = this.transform;
        }
    }
    private IEnumerator DeleteTarget(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        Destroy(this.gameObject);
    }
}
