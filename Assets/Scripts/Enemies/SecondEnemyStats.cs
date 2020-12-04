using UnityEngine;
using UnityEngine.UI;

public class SecondEnemyStats : MonoBehaviour
{
    private short HealthPoint = 2;
    private string[] Collisions = { "Bullet" };
    private Text Score;
    void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        foreach (string i in Collisions)
        {
            if (col.tag == i)
            {
                --HealthPoint;
            }
        }
        if (HealthPoint == 0)
        {
            short Points = short.Parse(Score.text);
            ++Points;
            Score.text = Points.ToString();
            Destroy(this.gameObject);
        }
    }
}
