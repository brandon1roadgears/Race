using UnityEngine;

namespace ScriptableStatsObject
{
    [CreateAssetMenu(fileName = "EnemyParametres", menuName = "ScriptableObjects/Enemies", order = 1)]
    public class EnemyStatsScOb : ScriptableObject
    {
        [Header("\tEnemy Stats")]
        [SerializeField] private Sprite EnemySprite;
        [SerializeField] private Color DestroyColor;
        [SerializeField] private GameObject DestroyAnimation;
        [SerializeField] private RuntimeAnimatorController Controller;
        [SerializeField] private int HealthPoint;
        [SerializeField] private int Reward;
        [SerializeField] private int Cost;
        [SerializeField] private string[] Collisions;

        [Header("\tEnemy Stats")] [Space(height: 25)]
        [SerializeField] private GameObject Bullet;
        [SerializeField] private Sprite BulletSprite;
        [SerializeField] private Vector2 BulletScale;
        [SerializeField] private Color BulletColor;
        [SerializeField] private float BulletMass;
        [SerializeField] private string BulletTag;

        public GameObject bullet
        {
            get {return Bullet;}
        }
        public RuntimeAnimatorController controller
        {
            get {return Controller;}
        }
        public Sprite enemySprite
        {
            get {return EnemySprite;}
        }
        public Sprite bulletSprite
        {
            get {return BulletSprite;}
        }
        public Vector2 bulletScale
        {
            get {return BulletScale;}
        }
        public Color bulletColor
        {
            get {return BulletColor;}
        }
        public Color destroyColor
        {
            get {return DestroyColor;}
        }
        public GameObject destroyAnimation
        {
            get {return DestroyAnimation;}
        }
        public float bulletMass
        {
            get {return BulletMass;}
        }
        public string bulletTag
        {
            get {return BulletTag;}
        }
        public int healthPoint
        {
            get {return HealthPoint;}
        }
        public int reward
        {
            get {return Reward;}
        }
        public int cost
        {
            get {return Cost;}
        }
        public string[] collisions
        {
            get {return Collisions;}
        }
    }
}
