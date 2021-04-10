using UnityEngine;
using System.Collections.Generic;

public class ClosePortal : MonoBehaviour
{
    private List<Transform> BlockAndGuard;

    private void Start()
    {
        if(BlockAndGuard == null)
        {
            Debug.Log("YESSSS");
        }
    }
    private void Update()
    {
        CheckBlocksAndGuard();
    }

    private void CheckBlocksAndGuard()
    {
        foreach(Transform i in BlockAndGuard)
        {
            if(i != null)
            {
                return;
            }
        }
        Destroy(this.gameObject);
    }
    internal void SetBlocksAndGuard(List<Transform> blockAndGuard, Transform Guardian)
    {
        BlockAndGuard = blockAndGuard;
        BlockAndGuard.Add(Guardian);
    }
}