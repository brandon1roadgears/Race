﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private short HealthPoint = 0;
    [SerializeField] private int PlusScore = 0;
    [SerializeField] private GameObject DestroyAnimation = null;
    private Text Score = null;
    private SpawnBehaviour SpaBeh = null;
    private ScoreManager _ScoreManager;
    private string[] Collisions = { "PlayerBullet" };
    internal int MyPosition = 0;
    
    private void Start()
    {
        Score = GameObject.Find("Text(Points)").GetComponent<Text>();
        SpaBeh = Camera.main.GetComponent<SpawnBehaviour>();
        _ScoreManager = Camera.main.GetComponent<ScoreManager>();
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
            _ScoreManager.AddMultiplier(PlusScore);
            Instantiate(DestroyAnimation, this.transform.localPosition, this.transform.localRotation);
            SpaBeh.SetFreePlaceInArray(MyPosition, this.gameObject.name[0]);
            Destroy(this.gameObject);
        }
    }
}
