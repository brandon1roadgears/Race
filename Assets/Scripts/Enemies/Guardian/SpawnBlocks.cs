using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] private GameObject BlockBox = null;
    [SerializeField] private GameObject Teleport = null;
    private List<Transform> Blocks = new List<Transform>();
    private bool IsBlockSpawn = true;
    private float Distance = 0.6f, Border = 0.0f, Go = 0.0f, Out = 0.0f;

    private void Start()
    {
        Border = Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x;
    }

    private void Update()
    {
        if(IsBlockSpawn && this.transform.position.x - Distance > Border)
        {
            IsBlockSpawn = false;
            StartCoroutine(BlockSpawn());
        }
        else if(this.transform.position.x - Distance <= Border)
        {
            BlockMove Bm = null;
            foreach(Transform block in Blocks)
            {
                if(block == null)
                {
                    continue;
                }
                Bm = block.GetComponent<BlockMove>();
                Bm.enabled = true;
                Bm._go = Go;
                Bm._out = Out;
            }
            Bm = GetComponent<BlockMove>();
            Bm.enabled = true;
            Bm._go = Go;
            Bm._out = Out;
            this.GetComponent<Animator>().SetBool("IsInGuardMod", false);
            Instantiate(Teleport, new Vector2(Go, this.transform.position.y), this.transform.rotation).GetComponent<ClosePortal>().SetBlocksAndGuard(Blocks, this.transform);
            Instantiate(Teleport, new Vector2(Out, this.transform.position.y), this.transform.rotation).GetComponent<ClosePortal>().SetBlocksAndGuard(Blocks, this.transform);
            this.enabled = false;
        }
    }
    IEnumerator BlockSpawn()
    {
        yield return new WaitForSeconds(0.4f);
        Blocks.Add(Instantiate(BlockBox, new Vector2(this.transform.position.x + Distance, this.transform.position.y), this.transform.rotation).transform);
        Out = Blocks[Blocks.Count - 1].transform.position.x;
        Blocks.Add(Instantiate(BlockBox, new Vector2(this.transform.position.x - Distance, this.transform.position.y), this.transform.rotation).transform);
        Go = Blocks[Blocks.Count - 1].transform.position.x;
        Distance += 0.6f;
        IsBlockSpawn = true;
    }
}
