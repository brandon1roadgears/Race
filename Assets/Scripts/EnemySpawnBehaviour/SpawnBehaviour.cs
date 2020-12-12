using UnityEngine;
using UnityEngine.UI;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] 
    private GameObject Enemy1 = null, Enemy2 = null, Enemy3 = null;
    private Text ScorePoints = null;
    private EnemySpawnData[] EnSpDa = null;
    private int Score = 0;
    private bool IsCall = false;
    
    private struct EnemySpawnData
    {
        public GameObject EnemyType;
        public Vector2 EnemyPos;
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
            case int z when (z == 0 && z <= 10 && !IsCall):
                IsCall = true;
                LightScript1(1);
                break;

            case int z when (z >= 11 && z <= 20 &&!IsCall):
                IsCall = true;
                LightScript1(2);
                break;

            case int z when (z >= 21 && z <= 30):
                //StartCorutine()
                break;

            case int z when (z >= 31 && z <= 40):
                //StartCorutine()
                break;

            case int z when (z >= 41 && z <= 50):
                //StartCorutine()
                break;

            case int z when (z >= 51 && z <= 60):
                //StartCorutine()
                break;
        }
    }

    private void LightScript1(int HowMany)
    {
        EnSpDa = new EnemySpawnData[HowMany];
        for(int i = 0; i < HowMany; ++i)
        {
            EnSpDa[i].EnemyType = Enemy1;
            EnSpDa[i].EnemyPos = new Vector2(Random.Range(-2f, 5f), Random.Range(-2f, 5f));
        }
        foreach(var i  in EnSpDa)
        {
            Instantiate(i.EnemyType, i.EnemyPos, new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
