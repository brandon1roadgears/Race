using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Invader1 = null, Invader2 = null, Invader3 = null;
    private Text ScorePoints = null;
    private int Score = 0;
    private bool IsCalledSpawn = true;
    private int CountOfFreePlace = 18;

    private GameObject[] Enemies = null;
    private Vector2[] ArrayOfPositions = null;
    private int[] A = null;
    private int[] B = null;
    
    internal int CountOfEnemies = 0;

    private void Start()
    {
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
        Enemies = new GameObject[3];
        Enemies[0] = Invader1;
        Enemies[1] = Invader2;
        Enemies[2] = Invader3;
        ArrayOfPositions = new Vector2[18] { new Vector2(-5.75f, 3.068759f), new Vector2(-4.25f, 3.068759f), new Vector2(-2.75f, 3.068759f),
                                             new Vector2(-1.25f, 3.068759f), new Vector2(0.25f, 3.068759f), new Vector2(1.75f, 3.068759f),

                                             new Vector2(-5.42f, 1.86f), new Vector2(-3.92f, 1.86f), new Vector2(-2.42f, 1.86f),
                                             new Vector2(-0.9200001f, 1.86f), new Vector2(0.5799999f, 1.86f), new Vector2(2.08f, 1.86f),

                                             new Vector2(-5.75f, 0.3f), new Vector2(-4.25f, 0.3f), new Vector2(-2.75f, 0.3f),
                                             new Vector2(-1.25f, 0.3f), new Vector2(0.25f, 0.3f), new Vector2(1.75f, 0.3f) };
    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        Score = int.Parse(ScorePoints.text);
        if (CheckEnemies() && IsCalledSpawn) 
        {
            IsCalledSpawn = false;
            switch (Score)
            {
                case int Points when (Points >= 0 && Points <= 10):
                    StartCoroutine(LightScript1(1));
                    break;

                case int Points when (Points >= 11 && Points <= 20):
                    StartCoroutine(LightScript1(2));
                    break;

                case int Points when (Points >= 21 && Points <= 30):
                    StartCoroutine(LightScript1(3));
                    break;

                case int Points when (Points >= 31 && Points <= 40):
                    StartCoroutine(LightScript1(4));
                    break;

                case int Points when (Points >= 41 && Points <= 50):
                    StartCoroutine(LightScript1(5));
                    break;

                case int Points when (Points >= 51 && Points <= 60):
                    StartCoroutine(LightScript1(6));
                    break;

                case int Points when (Points >= 61 && Points <= 70):
                    StartCoroutine(LightScript1(7));
                    break;

                case int Points when (Points >= 71 && Points <= 80):
                    StartCoroutine(LightScript1(8));
                    break;

                case int Points when (Points >= 81):
                    StartCoroutine(LightScript1(9));
                    break;
            }
        }
    }
    private IEnumerator LightScript1(int HowMany)
    {
        yield return new WaitForSeconds(1.5f);
        CountOfFreePlace = 18;
        B = new int[CountOfFreePlace];
        for (int i = 0; i < CountOfFreePlace; ++i)
        {
            B[i] = i;
        }
        for (byte i = 0; i < HowMany; ++i)
        {
            int Rnd = Random.Range(0, CountOfFreePlace);
            Instantiate(Enemies[Random.Range(0, 3)], ArrayOfPositions[B[Rnd]], new Quaternion(0f, 0f, 0f, 0f));
            B[Rnd] = -1;
            A = B;
            --CountOfFreePlace;
            B = new int[CountOfFreePlace];
            for(int j = 0, z = 0; j < CountOfFreePlace + 1; ++j)
            {
                if(A[j] != -1)
                {
                    B[z] = A[j];
                    ++z;
                }
            }
        }
        IsCalledSpawn = true;
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
