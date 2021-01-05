using UnityEngine;

public class SetChousenSettings : MonoBehaviour
{
    [SerializeField] private GameObject ConfigurationPane1 = null;
    [SerializeField] private GameObject ConfigurationPane2 = null;
    [SerializeField] private GameObject ConfigurationPane3 = null;

    private ButtonEvent Be = null;
    private void Start()
    {        
        Be = GameObject.Find("Canvas").GetComponent<ButtonEvent>();

        if(Be.GetValueOfConfiguration() == 1)
        {
            ConfigurationPane1.SetActive(true);
            ConfigurationPane2.SetActive(false);
            ConfigurationPane3.SetActive(false);
        }
        else if(Be.GetValueOfConfiguration() == 2)
        {
            ConfigurationPane1.SetActive(false);
            ConfigurationPane2.SetActive(true);
            ConfigurationPane3.SetActive(false);
        }
        else if(Be.GetValueOfConfiguration() == 3)
        {
            ConfigurationPane1.SetActive(false);
            ConfigurationPane2.SetActive(false);
            ConfigurationPane3.SetActive(true);

        }
    }
}
