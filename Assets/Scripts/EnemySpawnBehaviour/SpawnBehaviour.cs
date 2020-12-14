﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Invader1 = null, Invader2 = null, Invader3 = null;
    private GameObject[] Enemies = new GameObject[3];
    private Text ScorePoints = null;
    private int Score = 0;
    private bool IsCalledSpawn = true;

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
            case int Points when (Points >= 0 && Points <= 10 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(1));
                break;

            case int Points when (Points >= 11 && Points <= 20 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(2));
                break;

            case int Points when (Points >= 21 && Points <= 30 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(3));
                break;

            case int Points when (Points >= 31 && Points <= 40 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(4));
                break;

            case int Points when (Points >= 41 && Points <= 50 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(5));
                break;

            case int Points when (Points >= 51 && Points <= 60 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(6));
                break;

            case int Points when (Points >= 61 && Points <= 70 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(7));
                break;

            case int Points when (Points >= 71 && Points <= 80 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(8));
                break;

            case int Points when (Points >= 81 && CheckEnemies() && IsCalledSpawn):
                IsCalledSpawn = false;
                StartCoroutine(LightScript1(9));
                break;
        }
    }
    private IEnumerator LightScript1(int HowMany)
    {
        yield return new WaitForSeconds(1.5f);
        for(byte i = 0; i < HowMany; ++i)
        {
            Instantiate(Enemies[Random.Range(0, 3)], new Vector2(Random.Range(-7f, 3f), Random.Range(3f, 1.2f)), new Quaternion(0f, 0f, 0f, 0f));
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
