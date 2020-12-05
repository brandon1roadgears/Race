using UnityEngine;
using System.Collections;

public class SecondEnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private Transform ShootPoint;
    private bool IsShooting = true;
    
    void Start()
    {
        ShootPoint = GameObject.Find("Enemy2ShootPoint").GetComponent<Transform>();  
    }

    void Update()
    {
        if (IsShooting)
        {
            IsShooting = false;
            StartCoroutine(ShootLogic());
        }
    }

    private IEnumerator ShootLogic()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject Bull = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        IsShooting = true;
    }
}
