using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private short HealthPoint = 0;
    [SerializeField] private short PlusScore = 0;
    [SerializeField] private GameObject DestroyAnimation = null;
    private Text Score = null;
    private SpawnBehaviour SpaBeh = null;
    private string[] Collisions = { "PlayerBullet" };
    internal int MyPosition = 0;
    
    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
        SpaBeh = Camera.main.GetComponent<SpawnBehaviour>();
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
            Points += PlusScore;
            Score.text = Points.ToString();
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            SpaBeh.SetFreePlaceInArray(MyPosition, this.gameObject.name[0]);
            Destroy(this.gameObject);
        }
    }
}
