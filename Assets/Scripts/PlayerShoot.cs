using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform ShootPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLogic();
        }
    }
    
    private void ShootLogic()
    {
        GameObject Bull = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
    }
    
}
