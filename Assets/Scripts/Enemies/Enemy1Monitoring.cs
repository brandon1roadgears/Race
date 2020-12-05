using UnityEngine;

public class Enemy1Monitoring : MonoBehaviour
{
    private Transform PlayerPosition;

    void Start()
    {
        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>();    
    }

    void Update()
    {
        this.transform.LookAt2D(this.transform.up, PlayerPosition);
    }
}
