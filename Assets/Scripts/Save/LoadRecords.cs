﻿using UnityEngine;
using UnityEngine.UI;

public class LoadRecords : MonoBehaviour
{
    [SerializeField] Text [] Records = new Text[10];
    [SerializeField] private Slider MusicSlider = null, SoundSlider = null;
    [SerializeField] private GameObject[] ChousenConfiguration = new GameObject[10];
    private CreateSaveFiles _CreateSaveFiles;

    void Start()
    {
        _CreateSaveFiles = Camera.main.GetComponent<CreateSaveFiles>();   
        for(int i = 9; i > -1; --i)
        {
            if(_CreateSaveFiles._RecordsArray.Records[i] != -1)
            {
                Records[9 - i].text = _CreateSaveFiles._RecordsArray.Records[i].ToString();
            }
        }
        MusicSlider.value = _CreateSaveFiles._RecordsSettings.MusicVolume;
        SoundSlider.value = _CreateSaveFiles._RecordsSettings.SoundsVolume;
        ChousenConfiguration[_CreateSaveFiles._RecordsSettings.TypeOfControl].SetActive(true);        
    }
} 
