using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet = null;
    private float WaitingTime = 0.0f;
    private Transform ShootPoint = null;
    private bool IsShooting = true;

    private void Start()
    {
        ShootPoint = transform.GetChild(0).GetComponent<Transform>();
        WaitingTime = Random.Range(0.8f, 2.5f);
    }

    private void Update()
    {
        if (IsShooting)
        {
            IsShooting = false;
            StartCoroutine(ShootLogic());
        }
    }

    private IEnumerator ShootLogic()
    {
        yield return new WaitForSeconds(WaitingTime);
        GameObject Bull = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        IsShooting = true;
    }
}
