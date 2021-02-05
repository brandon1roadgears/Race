using UnityEngine;

public class SetHandle : MonoBehaviour
{
    [SerializeField] private Transform Handle = null;
    private PlayerAction _PlayerAction = null;

    private void Awake()
    {
        _PlayerAction = GameObject.Find("Player").GetComponent<PlayerAction>();
    }

    private void OnEnable()
    {
        _PlayerAction.MainHandle = Handle;
    }
}
