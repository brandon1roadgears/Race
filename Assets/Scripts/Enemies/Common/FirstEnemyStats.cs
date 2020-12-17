using UnityEngine;
using UnityEngine.UI;

public class FirstEnemyStats : MonoBehaviour
{
    [SerializeField] private short HealthPoint = 1;
    private Animator DestroyAnimation = null;
    private string[] Collisions = { "PlayerBullet" };
    private Text Score = null;
    private SpawnBehaviour SpaBeh = null;

    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
        SpaBeh = GameObject.Find("Main Camera").GetComponent<SpawnBehaviour>();
        ++SpaBeh.CountOfEnemies;
        DestroyAnimation = this.GetComponent<Animator>();
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
            --SpaBeh.CountOfEnemies;
            short Points = short.Parse(Score.text);
            ++Points;
            Score.text = Points.ToString();
            DestroyAnimation.SetBool("IsDead", true);
            Destroy(this.gameObject, DestroyAnimation.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}
