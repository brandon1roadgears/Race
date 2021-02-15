using UnityEngine;

public class EnemyMonitoring : MonoBehaviour
{
    private Transform PlayerPosition = null;

    private void Start()
    {
        PlayerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(PlayerPosition != null)
        {
            this.transform.LookAt2D(this.transform.up, PlayerPosition);
        }
    }
}
