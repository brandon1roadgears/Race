using UnityEngine;

public class SetChousenSettings : MonoBehaviour
{
    [SerializeField] private GameObject ConfigurationPane1 = null;
    [SerializeField] private GameObject ConfigurationPane2 = null;
    private ButtonEvent Be = null;
    private void Start()
    {        
        Be = GameObject.Find("Canvas").GetComponent<ButtonEvent>();

        if(Be.GetValueOfConfiguration()){
            ConfigurationPane1.SetActive(true);
            ConfigurationPane2.SetActive(false);
        }
        else
        {
            ConfigurationPane1.SetActive(false);
            ConfigurationPane2.SetActive(true);
        }
    }
}
