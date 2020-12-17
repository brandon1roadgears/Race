using UnityEngine;
using UnityEngine.UI;

public class FirstEnemyStats : MonoBehaviour
{
    [SerializeField] private short HealthPoint = 1;
    [SerializeField] private GameObject DestroyAnimation = null;
    private string[] Collisions = { "PlayerBullet" };
    private Text Score = null;
    private SpawnBehaviour SpaBeh = null;

    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
        SpaBeh = GameObject.Find("Main Camera").GetComponent<SpawnBehaviour>();
        ++SpaBeh.CountOfEnemies;
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
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            Destroy(this.gameObject);
        }
    }
}
