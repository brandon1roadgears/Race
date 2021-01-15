using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour
{
    #region using System
    private int Score = 0;                                                                              //Varaible for converting from Text ScorePoints to to int
    private bool IsCalledSpawn = true;                                                                  //Variable for Waiting of Coroutines
    private int CountOfFreePlace = 22;               
    private int[] A = null;
    private int[] B = null;
    internal int CountOfEnemies = 0;
#endregion

    #region using UnityEngine
    [SerializeField] private GameObject Invader1 = null,                                                //Objects that contains Enemies;
                                        Invader2 = null, 
                                        Invader3 = null, 
                                        Ufo = null;                                                     

    private GameObject[] StaticEnemies = null;                                                          //Array of non-moving invaders
    private GameObject[] DinamicEnemies = null;                                                         //Array of moving invaders
    private Vector2[] ArrayOfStaticEnemiesPositions = null,
                      ArrayOfDinamicEnemiesPositions = null,
                      ArrayOfUfoPositions = null, 
                      ArrayEnemyWithUfo = null;
    private Text ScorePoints = null;                                                                    //Variable required for getting points from UJ                                                   
#endregion

    private void Start()
    {
        #region GetComponents<>
        
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
        
        #endregion

        #region CREATING_ARRAYS_WITH_DIFFERENT_SETS_OF_INVADERS_COMBINATIONS

        StaticEnemies = new GameObject[2]
        { 
            Invader1,
            Invader3
        };

        DinamicEnemies = new GameObject[1]
        {
            Invader2
        };

        #endregion

        #region CREATING_ARRAYS_WITH_POSITIONS_OF_INVADERS

        ArrayOfStaticEnemiesPositions = new Vector2[22] 
        { 
          new Vector2(-3.68f, 1.85f), new Vector2(-2.68f, 1.85f), new Vector2(-1.68f, 1.85f),new Vector2(-0.68f, 1.85f), 
          new Vector2(0.32f, 1.85f), new Vector2(1.32f, 1.85f), new Vector2(2.32f, 1.85f), new Vector2(3.32f, 1.85f),

          new Vector2(-3.68f, 0.89f), new Vector2(-2.68f, 0.89f), new Vector2(-0.68f, 0.89f),
          new Vector2(0.32f, 0.89f), new Vector2(2.32f, 0.89f), new Vector2(3.32f, 0.89f),

          new Vector2(-3.68f, 0.15f), new Vector2(-2.68f, 0.15f), new Vector2(-1.68f, 0.15f),new Vector2(-0.68f, 0.15f), 
          new Vector2(0.32f, 0.15f), new Vector2(1.32f, 0.15f), new Vector2(2.32f, 0.15f), new Vector2(3.32f, 0.15f)
        };

        ArrayOfDinamicEnemiesPositions = new Vector2[8]
        {
            new Vector2(-3.14f, 1.37f), new Vector2(-0.14f, 1.37f), new Vector2(2.86f, 1.37f),new Vector2(-1.68f, 0.89f), 
            new Vector2(-3.14f, 0.37f), new Vector2(-0.14f, 0.37f), new Vector2(2.86f, 0.37f), new Vector2(1.32f, 0.89f),
        };

        ArrayOfUfoPositions = new Vector2[3] 
        { 
          new Vector2(Random.Range(-2.98f, 2.08f), 1.77f), 
          new Vector2(Random.Range(-2.98f, 2.08f), 0.88f), 
          new Vector2(Random.Range(-2.98f, 2.08f), -0.14f) 
        };

        ArrayEnemyWithUfo = new Vector2[3] 
        {
            new Vector2(-3.04f, 1.31f),
            new Vector2(0f, 0.37f),
            new Vector2(-3.02f, 1.37f)
        };

        #endregion
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

                case int Points when (Points == 11):                               
                    StartCoroutine(LightScript2(1, 0));
                    break;

                case int Points when (Points >= 12 && Points <= 22):               
                    StartCoroutine(LightScript1(2));
                    break;

                case int Points when (Points == 24):                               
                    StartCoroutine(LightScript2(2, 0));
                    break;

                case int Points when (Points >= 26 && Points <= 35):
                    StartCoroutine(LightScript1(3));
                    break;

                case int Points when (Points == 38):
                    StartCoroutine(LightScript2(2, 1));
                    break;

                case int Points when (Points >= 41 && Points <= 53):
                    StartCoroutine(LightScript1(4));
                    break;

                case int Points when (Points == 57):
                    StartCoroutine(LightScript2(2, 2));
                    break;

                case int Points when (Points >= 61 && Points <= 76):
                    StartCoroutine(LightScript1(5));
                    break;

                case int Points when (Points == 81):
                    StartCoroutine(LightScript2(3, 0));
                    break;

                case int Points when (Points >= 84 && Points <= 102):
                    StartCoroutine(LightScript1(6));
                    break;

                case int Points when (Points == 108):
                    StartCoroutine(LightScript2(3, 1));
                    break;

                case int Points when (Points >= 112 && Points <= 133):
                    StartCoroutine(LightScript1(7));
                    break;

                case int Points when (Points == 140):
                    StartCoroutine(LightScript2(3, 2));
                    break;

                case int Points when (Points >= 145 && Points <= 169):
                    StartCoroutine(LightScript1(8));
                    break;

                case int Points when (Points == 177):
                    StartCoroutine(LightScript2(3, 3));
                    break;

                case int Points when (Points >= 183):
                    StartCoroutine(LightScript1(9));
                    break;
            }
        }
    }

    private IEnumerator LightScript2(int CountOfUfo, int CountOfOther)                                              /**/
    {
        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i < CountOfUfo; ++i)
        {
            Instantiate(Ufo, ArrayOfUfoPositions[i], new Quaternion(0f, 0f, 0f, 0f));
        }
        for(int i = 0; i < CountOfOther; ++i)
        {
            Instantiate(StaticEnemies[Random.Range(0, 3)], ArrayEnemyWithUfo[i], new Quaternion(0f, 0f, 0f, 0f));
        }
        IsCalledSpawn = true;
    }

    private IEnumerator LightScript1(int HowMany)                                                                   /**/
    {
        yield return new WaitForSeconds(1.5f);
        PrepareArray();
        for (byte i = 0; i < HowMany; ++i)
        {
            SpawnOnRandomPlace();
            CheckOccupiedPlaces();
        }
        IsCalledSpawn = true;
    }

    private void PrepareArray()
    {
        CountOfFreePlace = 18;
        B = new int[CountOfFreePlace];
        for (int i = 0; i < CountOfFreePlace; ++i)
        {
            B[i] = i;
        }
    }

    private void SpawnOnRandomPlace()
    {
        int Rnd = Random.Range(0, CountOfFreePlace);
        Instantiate(StaticEnemies[Random.Range(0, 3)], ArrayOfStaticEnemiesPositions[B[Rnd]], new Quaternion(0f, 0f, 0f, 0f));
        B[Rnd] = -1;
    }

    private void CheckOccupiedPlaces()
    {
        A = B;
        --CountOfFreePlace;
        B = new int[CountOfFreePlace];
        for (int j = 0, z = 0; j < CountOfFreePlace + 1; ++j)
        {
            if (A[j] != -1)
            {
                B[z] = A[j];
                ++z;
            }
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
