using System.Collections;
using UnityEngine;

public class UfoShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet = null;
    private Transform ShootPoint = null;
    private bool IsShooting = true;
    
    private void Start()
    {
        ShootPoint = transform.GetChild(0).GetComponent<Transform>();
    }

    private void FixedUpdate()
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
        GameObject Bull = Instantiate(Bullet, ShootPoint.position, new Quaternion(ShootPoint.rotation.x, ShootPoint.rotation.y, ShootPoint.rotation.z, 180f));
        GameObject Bull1 = Instantiate(Bullet, new Vector2(ShootPoint.position.x + 0.76f, ShootPoint.position.y), new Quaternion(ShootPoint.rotation.x, ShootPoint.rotation.y, ShootPoint.rotation.z, 180f));
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        rb = Bull1.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
        IsShooting = true;  
    }
}
