using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet = null;
    private Transform ShootPoint = null;
    private AudioSource ShootSound = null;

    private void Start()
    {
        ShootPoint = GameObject.Find("PlayerShootPoint").GetComponent<Transform>();
        ShootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootLogic();
            ShootSound.Play();
        }
    }
    
    private void ShootLogic()
    {
        GameObject Bull = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
    }
    
}
