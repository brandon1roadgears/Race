using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnBehaviour : MonoBehaviour
{
    private float WaitingTimeForStatic = 4f, WaitingTimeForLeftRight = 5f, WaitingTimeForUfo = 5f;
    private bool[] IsSpawn = new bool[] {true, true, true};
    bool isChangedWaitingTime = true;

    [SerializeField] private GameObject Green = null, Red = null, Purple = null, Ufo = null;

    private List<int> FreePositions = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
    private List<int> FreeLeftRightPositions = new List<int> {0, 1, 2, 3, 4, 5};
    private List<int> FreeUfoPositions = new List<int> {0, 1, 2};
    private Text ScorePoints = null;
    private GameObject[] StaticEnemiesKit = null, LeftRightEnemiesKit = null, Ufos = null;
    private Vector2[] ArrayOfStaticEnemiesPositions = new Vector2[]
    {
        new Vector2(-3.5f, 1.85f), new Vector2(-2.5f, 1.85f),
        new Vector2(-0.5f, 1.85f), new Vector2(0.5f, 1.85f),
        new Vector2(2.5f, 1.85f), new Vector2(3.5f, 1.85f),

        new Vector2(-4.27f, 1.4f), new Vector2(-1.5f, 1.4f),
        new Vector2(1.5f, 1.4f), new Vector2(4.27f, 1.4f),
        
        new Vector2(-4.27f, 0.3f), new Vector2(-1.5f, 0.3f),
        new Vector2(1.5f, 0.3f), new Vector2(4.27f, 0.3f),

        new Vector2(-3.5f, -0.15f),new Vector2(-2.5f, -0.15f),
        new Vector2(-0.5f, -0.15f),new Vector2(0.5f, -0.15f),
        new Vector2(2.5f, -0.15f),new Vector2(3.5f, -0.15f),
    };

    private Vector2[] ArrayOfLeftRightEnemiesPositions = new Vector2[]
    {
        new Vector2(-3f, 1.37f), new Vector2(0f, 1.37f), new Vector2(3f, 1.37f),
        new Vector2(-3f, 0.37f), new Vector2(0f, 0.37f), new Vector2(3f, 0.37f)
    };

    private Vector2[] ArrayOfUfoPositions = new Vector2[]
    {
        new Vector2(6.03f, 2.3f),
        new Vector2(-6.09f, 0.88f),
        new Vector2(6.03f, -0.65f)        
    };

    private void Start()
    {
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
        StaticEnemiesKit = new GameObject[]
        {
            Green, Purple
        };
        LeftRightEnemiesKit = new GameObject[]
        {
            Red
        };
        Ufos = new GameObject[]
        {
            Ufo
        };
    }

    private void Update()
    {
        CheckScript();
        if(isChangedWaitingTime){
            isChangedWaitingTime = false;
            StartCoroutine(CheckWaitingTime());
        }
    }

    private void CheckScript()
    {
        switch(Time.timeSinceLevelLoad)
        {
            case float Timer when (Timer < 120 && IsSpawn[0]):
                IsSpawn[0] = false;
                StartCoroutine(UniversalSpawn(StaticEnemiesKit, ArrayOfStaticEnemiesPositions, FreePositions, WaitingTimeForStatic, IsSpawn, 0));
                break;

            case float Timer when (Timer >= 120 && Timer < 240):
                if(IsSpawn[0])
                {
                    IsSpawn[0] = false;
                    StartCoroutine(UniversalSpawn(StaticEnemiesKit, ArrayOfStaticEnemiesPositions, FreePositions, WaitingTimeForStatic, IsSpawn, 0));
                }
                if(IsSpawn[1])
                {
                    IsSpawn[1] = false;
                    StartCoroutine(UniversalSpawn(LeftRightEnemiesKit, ArrayOfLeftRightEnemiesPositions, FreeLeftRightPositions, WaitingTimeForLeftRight, IsSpawn, 1));
                }
                break;
            
            case float Timer when (Timer >= 240):
                if(IsSpawn[0])
                {
                    IsSpawn[0] = false;
                    StartCoroutine(UniversalSpawn(StaticEnemiesKit, ArrayOfStaticEnemiesPositions, FreePositions, WaitingTimeForStatic, IsSpawn, 0));
                }
                if(IsSpawn[1])
                {
                    IsSpawn[1] = false;
                    StartCoroutine(UniversalSpawn(LeftRightEnemiesKit, ArrayOfLeftRightEnemiesPositions, FreeLeftRightPositions, WaitingTimeForLeftRight, IsSpawn, 1));
                }
                if(IsSpawn[2])
                {
                    IsSpawn[2] = false;
                    StartCoroutine(UniversalSpawn(Ufos, ArrayOfUfoPositions, FreeUfoPositions, WaitingTimeForUfo, IsSpawn, 2));
                }
            break;
        }
    }
    private IEnumerator CheckWaitingTime()
    {
        yield return new WaitForSeconds(30f);
        switch((int)Time.timeSinceLevelLoad)
        {
            case int Timer when(Timer == 30):
                WaitingTimeForStatic -= 1.5f;
                break;
            case int Timer when(Timer == 60):
                WaitingTimeForStatic -= 1f;
                break;
            case int Timer when(Timer == 120):
                WaitingTimeForStatic += 1.2F;
                WaitingTimeForLeftRight -= 0.5f;
                break;
            case int Timer when(Timer == 150):
                WaitingTimeForLeftRight -= 0.5f;
                break;
            case int Timer when(Timer == 240):
                WaitingTimeForStatic += 0.3f;
                break;
        }
        isChangedWaitingTime = true;
    }

    private IEnumerator UniversalSpawn(GameObject[] Who, Vector2[] Where, List<int> FreePositions, float WaitingTime, bool[] isSpawn, int index)
    {
        yield return new WaitForSeconds(WaitingTime);
        if(FreePositions.Count != 0)
        {
            int EnemyOnSpawn = Random.Range(0, Who.Length);
            int SpawnPos = Random.Range(0, FreePositions.Count);
            GameObject Spawned = Instantiate(Who[EnemyOnSpawn], Where[FreePositions[SpawnPos]], new Quaternion(0f, 0f, 0f, 0f));
            Spawned.GetComponent<EnemyStats>().MyPosition = FreePositions[SpawnPos];
            FreePositions.RemoveAt(SpawnPos);
        }
        isSpawn[index] = true;
    }

    internal void SetFreePlaceInArray(int MyPosition, char Name)
    {
        switch(Name)
        {
            case char N when(N == 'G' || N == 'P'):
                FreePositions.Add(MyPosition);
                break;

            case 'R':
                FreeLeftRightPositions.Add(MyPosition);
                break;

            case 'U':
                FreeUfoPositions.Add(MyPosition);
                break;
        }
    } 
}
