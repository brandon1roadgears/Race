﻿using UnityEngine;
using System.Collections;

public class SecondEnemyMovement : MonoBehaviour
{
    float WaitingTime = 1.0f;
    private bool IsMoving = true;
    private float MoveDir = 0.0f;
    private float [] Rnd = {-1.5f, 1.5f};

    private void Start()
    {
        int e = Mathf.RoundToInt(Random.Range(0, 2));
        MoveDir = Rnd[e];
    }

    private void Update()
    {
        if (IsMoving)
        {
            IsMoving = false;
            MoveDir = -MoveDir;
            StartCoroutine(MoveEnemy2Logic());
        }
    }

    private IEnumerator MoveEnemy2Logic()
    {
        yield return new WaitForSeconds(WaitingTime);
        this.transform.position = new Vector2(this.transform.position.x + MoveDir, this.transform.position.y);
        IsMoving = true;
    }
}
