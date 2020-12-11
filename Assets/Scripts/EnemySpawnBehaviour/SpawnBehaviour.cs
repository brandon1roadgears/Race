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
            case int z when (z >= 0 && !IsCall):
                IsCall = true;
                LightScript1();
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

    private void LightScript1()
    {
        EnSpDa = new EnemySpawnData[5];
        for(int i = 0; i < 5; ++i)
        {
            EnSpDa[i].EnemyType = Enemy1;
        }
        EnSpDa[0].EnemyPos = new Vector3(-6.32f, 2.86f, 0f);
        EnSpDa[1].EnemyPos = new Vector3(-1.83f, 2.86f, 0f);
        EnSpDa[2].EnemyPos = new Vector3( 2.67f, 2.86f, 0f);
        EnSpDa[3].EnemyPos = new Vector3(-4.08f, 1.36f, 0f);
        EnSpDa[4].EnemyPos = new Vector3(-0.67f, 1.36f, 0f);
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(EnSpDa[i].EnemyType, EnSpDa[i].EnemyPos, new Quaternion(0f,0f,0f,0f));
        }
    }
}
