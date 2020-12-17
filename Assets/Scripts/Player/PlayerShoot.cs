using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet = null;
    [SerializeField] private AudioClip ShootSound = null;
    private Transform ShootPoint = null;
    private AudioSource SoundPlay = null;
    

    private void Start()
    {
        ShootPoint = GameObject.Find("PlayerShootPoint").GetComponent<Transform>();
        SoundPlay = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundPlay.PlayOneShot(ShootSound);
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
