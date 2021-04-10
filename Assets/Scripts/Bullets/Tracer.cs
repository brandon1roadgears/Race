using System.Collections;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    [SerializeField] private GameObject Trace = null;
    private bool IsSpawnTrace = true;

    private void Update()
    {
        if(IsSpawnTrace)
        {
            IsSpawnTrace = false;
            StartCoroutine(LeaveTrace());
        }
    }
    
    private IEnumerator LeaveTrace()
    {
        yield return new WaitForSeconds(0.08f);
        Instantiate(Trace, this.transform.position, this.transform.rotation);
        IsSpawnTrace = true;
    }
}
