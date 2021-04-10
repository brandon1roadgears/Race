using UnityEngine;

namespace ScriptablePlayerStatsObject
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/Player", order = 0)]
    public class PlayerStatsScOb : ScriptableObject
    {
        [Header("PlayerStats")]
        [SerializeField] Sprite ShipSkin;
        [SerializeField] private GameObject DestroyAnimation;
        [SerializeField] private Color DestroyColor;
        [SerializeField] private int Healthpoint;
        [SerializeField] private string[] Collisions;

        [Header("PlayerBulletStats")]
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
        public GameObject destroyAnimation
        {
            get {return DestroyAnimation;}
        }
        public Sprite bulletSprite
        {
            get {return BulletSprite;}
        }
        public Sprite shipSkin
        {
            get {return ShipSkin;}
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
        public float bulletMass
        {
            get {return BulletMass;}
        }
        public string bulletTag
        {
            get {return BulletTag;}
        }
        public string[] collisions
        {
            get {return Collisions;}
        }
        public int healthPoint
        {
            get {return Healthpoint;}
        }
    }
}
