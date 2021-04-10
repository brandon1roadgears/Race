using UnityEngine;
using System.Collections;
using ScriptableStatsObject;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float WaitingTime = 0.0f;
    private EnemyStatsScOb _EnemyStats = null;
    private Transform[] ShootPoints = null;
    private bool IsShooting = true;

    private void Start()
    {
        _EnemyStats = this.GetComponent<EnemyStats>().enemyStats;
        ShootPoints = this.GetComponentsInChildren<Transform>();
        if(WaitingTime == 0.0f)
        {
            WaitingTime = Random.Range(0.8f, 2.5f);
        }
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
        GameObject bullet = null;
        Rigidbody2D bulletRigidBody = null;
        SpriteRenderer bulletSpriteRenderer = null;
        for(int i = 1; i < ShootPoints.Length; ++i)
        {
            SpawnBullet(ref bullet, ref bulletRigidBody, ref bulletSpriteRenderer, i);
            SetBulletPropeties(bullet, bulletRigidBody, bulletSpriteRenderer);
            Shoot(bulletRigidBody, i);
        }
        IsShooting = true;
    }

    private void SpawnBullet(ref GameObject _bullet, ref Rigidbody2D _bulletRigidBody, ref SpriteRenderer _bulletSpriteRenderer, int index)
    {
        _bullet = Instantiate(_EnemyStats.bullet, ShootPoints[index].transform.position, ShootPoints[index].transform.rotation);
        _bulletRigidBody = _bullet.AddComponent<Rigidbody2D>();
        _bulletSpriteRenderer = _bullet.AddComponent<SpriteRenderer>();

    }
    private void SetBulletPropeties(GameObject _bullet, Rigidbody2D _bulletRigodBody, SpriteRenderer _bulletSpriteRenderer)
    {
        _bullet.tag = _EnemyStats.bulletTag;
        _bullet.transform.localScale = _EnemyStats.bulletScale;
        _bulletSpriteRenderer.sprite = _EnemyStats.bulletSprite;
        _bulletSpriteRenderer.color = _EnemyStats.bulletColor;
        _bulletRigodBody.mass = _EnemyStats.bulletMass;
        _bulletRigodBody.angularDrag = 0.0f;
        _bulletRigodBody.gravityScale = 0.0f;
    }
    private void Shoot(Rigidbody2D _bulletRigidBody, int index)
    {
        _bulletRigidBody.AddForce(ShootPoints[index].up, ForceMode2D.Impulse);
    }
}
