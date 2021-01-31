using UnityEngine;
using Structs;
using System.IO;
using UnityEngine.SceneManagement;

public class UiMainGame : MonoBehaviour
{
    [SerializeField] private GameObject[] Configurations = new GameObject[8];
    private CreateSaveFiles _CreateSaveFiles = null;

    private void Start()
    {
        _CreateSaveFiles = this.GetComponent<CreateSaveFiles>();
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(false);
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(false);
    }
    public void OnHomeButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void OnRetryButtonCkick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }
}

