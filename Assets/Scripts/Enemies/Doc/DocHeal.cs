using UnityEngine;
using System.Collections;

public class DocHeal : MonoBehaviour
{
    private LineRenderer line = null;
    private GameObject[] EnemiesToHeal = new GameObject[3];
    private bool isFindingEnemiesToHeal = true;
    private void Start()
    {
        line = this.GetComponent<LineRenderer>();
        StartCoroutine(FindToHeal(0f));
    }
    private void Update()
    {
        if(isFindingEnemiesToHeal)
        {
            isFindingEnemiesToHeal = false;
            StartCoroutine(FindToHeal(3f));
        }
        DrawConnection();
    }

    private IEnumerator FindToHeal(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        GameObject[] FreeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int AbleLength = FreeEnemies.Length;
        if(AbleLength > 3) AbleLength = 3;
        for(int i = 0; i < AbleLength; ++i)
        {
            EnemiesToHeal[i] = FreeEnemies[i];
        }
        isFindingEnemiesToHeal = true;
    }

    private void DrawConnection()
    {
        if(EnemiesToHeal[0] != null)
        {
            line.SetPosition(0, EnemiesToHeal[0].transform.position);
            line.SetPosition(1, transform.position);
        }
        else
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position);
        }

        if(EnemiesToHeal[1] != null)
        {
            line.SetPosition(2, EnemiesToHeal[1].transform.position);
            line.SetPosition(3, transform.position);
        }
        else
        {
            line.SetPosition(2, transform.position);
            line.SetPosition(3, transform.position);
        }

        if(EnemiesToHeal[2] != null)
        {
            line.SetPosition(4, EnemiesToHeal[2].transform.position);
            line.SetPosition(5, transform.position);
        }
        else
        {
            line.SetPosition(4, transform.position);
            line.SetPosition(5, transform.position);
        }
    }
}
