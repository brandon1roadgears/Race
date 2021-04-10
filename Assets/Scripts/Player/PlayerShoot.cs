using UnityEngine;
using ScriptablePlayerStatsObject;

public class PlayerShoot : MonoBehaviour
{
    private PlayerStatsScOb _PlayerStats = null;
    private PlayerParameters _PlayerParameters = null;
    private Transform[] ShootPoints = null;

    private void Awake()
    {
        ShootPoints = this.GetComponentsInChildren<Transform>();
        _PlayerParameters = this.GetComponent<PlayerParameters>();
        _PlayerStats = this.GetComponent<PlayerStats>().playerStatsScOb;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ClickForShoot();
        }
    }

    public void ClickForShoot()
    {
        _PlayerParameters.soundPlay.PlayOneShot(_PlayerParameters.shootSound);
        GameObject bullet = null;
        Rigidbody2D bulletRigidBody = null;
        SpriteRenderer bulletSpriteRenderer = null;
        for(int i = 1; i < ShootPoints.Length; ++i)
        {   
            SpawnBullet(ref bullet, ref bulletRigidBody, ref bulletSpriteRenderer, i);
            SetBulletPropeties(bullet, bulletRigidBody, bulletSpriteRenderer);
            Shoot(bulletRigidBody, i);
        }
    }
    private void SpawnBullet(ref GameObject _bullet, ref Rigidbody2D _bulletRigidBody, ref SpriteRenderer _bulletSpriteRenderer, int index)
    {
        _bullet = Instantiate(_PlayerStats.bullet, ShootPoints[index].transform.position, ShootPoints[index].transform.rotation);
        _bulletRigidBody = _bullet.AddComponent<Rigidbody2D>();
        _bulletSpriteRenderer = _bullet.AddComponent<SpriteRenderer>();
    }
    private void SetBulletPropeties(GameObject _bullet, Rigidbody2D _bulletRigodBody, SpriteRenderer _bulletSpriteRenderer)
    {
        _bullet.tag = _PlayerStats.bulletTag;
        _bullet.transform.localScale = _PlayerStats.bulletScale;
        _bulletSpriteRenderer.sprite = _PlayerStats.bulletSprite;
        _bulletSpriteRenderer.color = _PlayerStats.bulletColor;
        _bulletRigodBody.mass = _PlayerStats.bulletMass;
        _bulletRigodBody.angularDrag = 0.0f;
        _bulletRigodBody.gravityScale = 0.0f;
    }
    private void Shoot(Rigidbody2D _bulletRigidBody, int index)
    {
        _bulletRigidBody.AddForce(ShootPoints[index].up, ForceMode2D.Impulse);
    }
}
