using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private short HealthPoint = 1;
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
            ++Points;
            Score.text = Points.ToString();
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            Debug.Log(this.gameObject.name[0]);
            if(this.gameObject.name[0] == 'R')
            {
                SpaBeh.SetFreePlaceForLeftRightEnemies(MyPosition);
            }
            else if(this.gameObject.name[0] == 'U')
            {
                SpaBeh.SetFreePlaceForUfoEnemies(MyPosition);
            }
            else
            {
                SpaBeh.SetFreePlaceInArray(MyPosition);
            }
            Destroy(this.gameObject);
        }
    }
}
