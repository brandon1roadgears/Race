using UnityEngine;
using ScriptableStatsObject;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private EnemyStatsScOb _EnemyStats = null;
    private SpawnBehaviour _SpawnBehaviour = null;
    private ScoreManager _ScoreManager = null;
    private GameObject DestroyAnimation = null;
    private Color DestroyColor;
    private int HealthPoint = 0;
    private int Reward = 0;
    internal int MyPosition = 0;
    private string[] Collisions;
    
    private void Awake()
    {
        _SpawnBehaviour = Camera.main.GetComponent<SpawnBehaviour>();
        _ScoreManager = Camera.main.GetComponent<ScoreManager>();
        this.gameObject.AddComponent<SpriteRenderer>().sprite = _EnemyStats.enemySprite;
        this.gameObject.AddComponent<Animator>().runtimeAnimatorController = _EnemyStats.controller;
        this.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        DestroyAnimation = _EnemyStats.destroyAnimation;
        HealthPoint = _EnemyStats.healthPoint;
        Reward = _EnemyStats.reward;
        Collisions = _EnemyStats.collisions;
        DestroyColor = _EnemyStats.destroyColor;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        foreach(string i in Collisions)
        {
            if (col.tag == i)
            {
                --HealthPoint;
            }
        }
        if (HealthPoint == 0)
        {
            _ScoreManager.AddMultiplier(Reward);
            Instantiate(DestroyAnimation, this.transform.position, this.transform.rotation).GetComponent<SpriteRenderer>().color = DestroyColor;
            _SpawnBehaviour.SetFreePlaceInArray(MyPosition, this.gameObject.name[0]);
            Destroy(this.gameObject);
        }
    }
    internal void HealingFromDoc()
    {
        ++HealthPoint;
    }

    internal EnemyStatsScOb enemyStats
    {
        get {return _EnemyStats;}
    }
}
