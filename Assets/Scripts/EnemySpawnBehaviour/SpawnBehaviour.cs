using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour
{
    private int Score = 0;
    private bool IsCalledSpawn = true;
    private int CountOfFreePlace = 22;
    private int[] A = null;
    private int[] B = null;
    private int PrevTimer = 0;
    internal int CountOfEnemies = 0;
    
    private Text ScorePoints = null;

    [SerializeField] private GameObject[] StaticEnemies;
    [SerializeField] private GameObject[] DinamicEnemies;
    private Vector2[] ArrayOfStaticEnemiesPositions = null;
    private Vector2[] ArrayOfDinamicEnemiesPositions = null;
    private Vector2[] ArrayOfUfoPositions = null;
    private Vector2[] ArrayEnemyWithUfoPositions = null;
    private Vector2[] ArrayOfEnemiesBehindScreenPositions = null;
    private void Start()
    {
        ScorePoints = GameObject.Find("Text(Points)").GetComponent<Text>();
    }
    private void Update()
    {
        
    }
}
