using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UiMainGame : MonoBehaviour
{
    [SerializeField] private GameObject[] Configurations = new GameObject[10];
    [SerializeField] private Toggle[] Toggles = new Toggle[10];
    [SerializeField] private AudioMixer MusicMixer = null, SoundMixer = null;
    [SerializeField] private Slider MusicSlider = null, SoundSlider = null;
    private CreateSaveFiles _CreateSaveFiles = null;
    private int CurrentConfiguration = 0;

    private void Start()
    {
        _CreateSaveFiles = Camera.main.GetComponent<CreateSaveFiles>();
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);
        Toggles[_CreateSaveFiles._RecordsSettings.TypeOfControl].isOn = true;
        CurrentConfiguration = _CreateSaveFiles._RecordsSettings.TypeOfControl;
        MusicSlider.value = _CreateSaveFiles._RecordsSettings.MusicVolume;
        SoundSlider.value = _CreateSaveFiles._RecordsSettings.SoundsVolume;
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(false);
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);
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

    public void ChangeConfigurationInGame()
    {
        Configurations[CurrentConfiguration].SetActive(false);
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);
        CurrentConfiguration = _CreateSaveFiles._RecordsSettings.TypeOfControl;
    }

    public void SetVolumeOfMusic(float Volume)
    {
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(Volume) * 20);
    }
    public void SetVolumeOfSounds(float Volume)
    {
        SoundMixer.SetFloat("SoundVolume", Mathf.Log10(Volume) * 20);
    }
}

