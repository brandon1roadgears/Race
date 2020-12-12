using UnityEngine;
using UnityEngine.UI;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Invader1 = null, Invader2 = null, Invader3 = null;
    private GameObject[] Enemies = new GameObject[3];
    private Text ScorePoints = null;
    private EnemySpawnData[] EnSpDa = null;
    private int Score = 0;

    internal int CountOfEnemies = 0;
    
    private struct EnemySpawnData
    {
        public GameObject EnemyType;
        public Vector2 EnemyPos;
    }

    private void Start()
    {
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
        Enemies[0] = Invader1;
        Enemies[1] = Invader2;
        Enemies[2] = Invader3;
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
            case int z when (z >= 0 && z <= 10 && CheckEnemies()):
                LightScript1(1);
                break;

            case int z when (z >= 11 && z <= 20 && CheckEnemies()):              
                LightScript1(2);
                break;

            case int z when (z >= 21 && z <= 30 && CheckEnemies()):
                LightScript1(3);
                break;

            case int z when (z >= 31 && z <= 40 && CheckEnemies()):
                LightScript1(4);
                break;

            case int z when (z >= 41 && z <= 50 && CheckEnemies()):
                LightScript1(5);
                break;

            case int z when (z >= 51 && z <= 60 && CheckEnemies()):
                LightScript1(6);
                break;
        }
    }
    private void LightScript1(int HowMany)
    {
        EnSpDa = new EnemySpawnData[HowMany];
        for(int i = 0; i < HowMany; ++i)
        {
            EnSpDa[i].EnemyType = Enemies[Random.Range(0, 3)];
            EnSpDa[i].EnemyPos = new Vector2(Random.Range(-7f, 3f), Random.Range(3f, 1.2f));
        }
        foreach(var i  in EnSpDa)
        {
            Instantiate(i.EnemyType, i.EnemyPos, new Quaternion(0f, 0f, 0f, 0f));
        }
    }

    

    private bool CheckEnemies()
    {
        if (CountOfEnemies == 0)
        {
            return true;
        }
        return false;
    }
}
