using System.Collections;
using UnityEngine;

public class ShrederAttack : MonoBehaviour
{
    private Transform PlayerPosition = null;
    private bool IsMonitoring = true;
    private float WaitingTime = 3.3f;
    private float ShrederSpeed = 0.016f;
    void Start()
    {
        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>(); 
        StartCoroutine(StopMonitoring());
    }

    void Update()
    {
        if(IsMonitoring)
        {
            this.transform.LookAt2D(-this.transform.up, PlayerPosition);
        }
        this.transform.Translate(Vector2.down * ShrederSpeed);
    }

    private IEnumerator StopMonitoring()
    {
        yield return new WaitForSeconds(WaitingTime);
        IsMonitoring = false;
    }
}
