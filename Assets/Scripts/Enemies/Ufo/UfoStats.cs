using UnityEngine;
using UnityEngine.UI;

public class UfoStats : MonoBehaviour
{
    private Text Score = null;
    private short HealthPoint = 4;
    private string[] Collisions = { "PlayerBullet" };

    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D col)
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
