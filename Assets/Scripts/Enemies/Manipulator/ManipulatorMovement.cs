using System.Collections;
using UnityEngine;

public class ManipulatorMovement : MonoBehaviour
{
    [SerializeField] private GameObject AutoTarget = null;
    private Transform Player = null;
    private bool IsSpawnTarget = true;
    private bool IsMoveToNextCorner = false;
    private Vector2[] Corners = new Vector2[4]
    {
        new Vector2(6.2f, 1.5f), new Vector2(-6.2f, 1.5f), new Vector2(6.2f, -2f), new Vector2(6.2f, -2f)
    };

    private void Start()
    {
        this.transform.position = Corners[Random.Range(0,4)];
        Player = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(SetIsMoveToNextCorner());
    }
    private void Update()
    {
        if(IsSpawnTarget)
        {
            IsSpawnTarget = false;
            StartCoroutine(StartTarget(3f));
        }
        if(IsMoveToNextCorner)
        {
            IsMoveToNextCorner = false;
            StartCoroutine(MoveToNextCorner(2f));
        }
    }
    
    private IEnumerator StartTarget(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        Instantiate(AutoTarget, Player.position, Player.rotation);
        IsSpawnTarget = true;
    }
    private IEnumerator MoveToNextCorner(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        this.transform.position = Corners[Random.Range(0,4)];
        IsMoveToNextCorner = true;
    }
    private IEnumerator SetIsMoveToNextCorner()
    {
        yield return new WaitForSeconds(3f);
        IsMoveToNextCorner = true;
    }
}
 