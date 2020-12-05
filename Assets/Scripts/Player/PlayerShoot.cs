using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    private Transform ShootPoint;

    private void Start()
    {
        ShootPoint = GameObject.Find("PlayerShootPoint").GetComponent<Transform>();
        Debug.Log(ShootPoint.name);
    }

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
