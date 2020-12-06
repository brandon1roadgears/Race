using System.Collections;
using UnityEngine;

public class UfoShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet = null;
    private Transform ShootPoint = null;
    private bool IsShooting = true;
    
    void Start()
    {
        ShootPoint = transform.GetChild(0).GetComponent<Transform>();
    }

    void FixedUpdate()
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
        GameObject Bull1 = Instantiate(Bullet, new Vector2(ShootPoint.position.x + 0.76f, ShootPoint.position.y), ShootPoint.rotation);
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        rb = Bull1.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        IsShooting = true;  
    }
}
