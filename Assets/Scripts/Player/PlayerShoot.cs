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

    public void ClickForShoot()
    {
            SoundPlay.PlayOneShot(ShootSound);
            GameObject Bull = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            Rigidbody2D rb = Bull.GetComponent<Rigidbody2D>();
            rb.AddForce(ShootPoint.up, ForceMode2D.Impulse);
    }
}
