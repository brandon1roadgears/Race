using UnityEngine;

public class UiMainGame : MonoBehaviour
{
    [SerializeField] private GameObject Configuration1 = null;
    [SerializeField] private GameObject Configuration2 = null;
    [SerializeField] private GameObject Configuration3 = null;

    private void Awake()
    {
        ButtonEvent BE = GetComponent<ButtonEvent>();
        if(BE.GetValueOfConfiguration() == 1)
        {
            Configuration1.SetActive(true);
            Configuration2.SetActive(false);
            Configuration3.SetActive(false);
        }
        else if(BE.GetValueOfConfiguration() == 2)
        {
            Configuration1.SetActive(false);
            Configuration2.SetActive(true);
            Configuration3.SetActive(false);
        }
        else if(BE.GetValueOfConfiguration() == 3)
        {
            Configuration1.SetActive(false);
            Configuration2.SetActive(false);
            Configuration3.SetActive(true);
        }
    }
}

