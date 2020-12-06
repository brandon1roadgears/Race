using UnityEngine;
using UnityEngine.UI;

public class FirstEnemyStats : MonoBehaviour
{
    private short HealthPoint = 1;
    private string[] Collisions = { "PlayerBullet" };
    private Text Score = null;

    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
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
            short Points = short.Parse(Score.text);
            ++Points;
            Score.text = Points.ToString();
            Destroy(this.gameObject);
        }
    }
}
