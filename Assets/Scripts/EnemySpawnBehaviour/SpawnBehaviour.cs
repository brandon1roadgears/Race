using UnityEngine;
using UnityEngine.UI;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] 
    private GameObject Enemy1 = null, Enemy2 = null, Enemy3 = null;
    private Text ScorePoints = null;
    private EnemySpawnData[] EsdLight1 = null;
    private int Score = 0;
    
    private struct EnemySpawnData
    {
        public GameObject EnemyType;
        public float x;
        public float y;
    }

    private void Start()
    {
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        Score = int.Parse(ScorePoints.text);
        switch (Score)
        {
            case int z when (z >= 0 && z <= 50) :
                //StartCorutine()
                break;

            case int z when (z >= 51 && z <= 99):
                //StartCorutine()
                break;

            case int z when (z >= 104 && z <= 199):
                //StartCorutine()
                break;

            case int z when (z >= 10000 && z <= 10000):
                //StartCorutine()
                break;

            case int z when (z >= 10000 && z <= 10000):
                //StartCorutine()
                break;

            case int z when (z >= 10000 && z <= 10000):
                //StartCorutine()
                break;
        }
    }

}
