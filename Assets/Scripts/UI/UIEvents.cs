﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;


public class UIEvents : MonoBehaviour
{
    [Header("COMMON VARIABLES")]
    [SerializeField] private Toggle[] Toggles = new Toggle[12];
    [SerializeField] private AudioMixer MusicMixer = null, SoundMixer = null;
    [SerializeField] private Slider MusicSlider = null, SoundSlider = null;
    [SerializeField] private PostProcessVolume _PostProcessVolume = null;
    private CreateSaveFiles _CreateSaveFiles = null;
    private AudioSource MenuListener = null;

    [Header("MENU VARIABLES")]
    [SerializeField] private AudioClip TestSound = null;
    [SerializeField] private Text[] Records = new Text[10];
    [SerializeField] private GameObject[] TutorialConf = new GameObject[5];
    

    [Header("MAINGAME VARIABLES")]
    [SerializeField] private GameObject[] Configurations = new GameObject[10];
    
    void Start()
    {
        _CreateSaveFiles = this.GetComponent<CreateSaveFiles>();
        MusicSlider.value = _CreateSaveFiles._RecordsSettings.MusicVolume;
        SoundSlider.value = _CreateSaveFiles._RecordsSettings.SoundsVolume;
        Toggles[_CreateSaveFiles._RecordsSettings.TypeOfControl].isOn = true;
        Toggles[10].isOn = _CreateSaveFiles._RecordsSettings.isBloom;
        Toggles[11].isOn = _CreateSaveFiles._RecordsSettings.isLense;
        _PostProcessVolume.profile.GetSetting<Bloom>().active = _CreateSaveFiles._RecordsSettings.isBloom;
        _PostProcessVolume.profile.GetSetting<LensDistortion>().active = _CreateSaveFiles._RecordsSettings.isLense;
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            MenuListener = GameObject.Find("SoundPoint").GetComponent<AudioSource>();
            for(int i = 0; i < 10; ++i)
            {
                if(_CreateSaveFiles._RecordsArray.Records[i] != -1)
                {
                    Records[i].text = _CreateSaveFiles._RecordsArray.Records[i].ToString();
                }
            }
        }
        else
        {
            Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);
        }
    }

    public void SetBloom(bool Value)
    {
        _PostProcessVolume.profile.GetSetting<Bloom>().active = Value;
    }
    public void SetLense(bool Value)
    {
        _PostProcessVolume.profile.GetSetting<LensDistortion>().active = Value;
    }
    public void OnPlayRetryButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
    }
    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
    }
    public void OnHomeButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void CheckSoundVolume()  
    {
        MenuListener.PlayOneShot(TestSound);
    }
    public void SetVolumeOfMusic(float Volume)
    {
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(Volume) * 20);
    }
    public void SetVolumeOfSounds(float Volume)
    {
        SoundMixer.SetFloat("SoundVolume", Mathf.Log10(Volume) * 20);
    }
    public void SetToggle(int ChousenToggle)
    {
        if(ChousenToggle != _CreateSaveFiles._RecordsSettings.TypeOfControl)
        {
            Toggles[ChousenToggle].isOn = true;
            Toggles[_CreateSaveFiles._RecordsSettings.TypeOfControl].isOn = false;
        }
    }
    public void SetConfiguration(int ChousenConfiguration)
    {
        Configurations[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(false);
        Configurations[ChousenConfiguration].SetActive(true);
    }
}
