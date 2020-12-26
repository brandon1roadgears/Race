using UnityEngine;

public class UiMainGame : MonoBehaviour
{
    [SerializeField] private GameObject Configuration1 = null;
    [SerializeField] private GameObject Configuration2 = null;

    private void Start()
    {
        ButtonEvent BE = GetComponent<ButtonEvent>();
        if(BE.GetValueOfConfiguration())
        {
            Configuration1.SetActive(true);
            Configuration2.SetActive(false);
        }
        else
        {
            Configuration1.SetActive(false);
            Configuration2.SetActive(true);
        }
    }
}

