using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    private CreateSaveFiles _CreateSaveFiles;
    private void Awake()
    {
        _CreateSaveFiles = this.GetComponent<CreateSaveFiles>();
    }

    internal void SaveResult(int Record)
    {
        
        int LastIndex = 0;
        for(int i = 0; i < 10; ++i)
        {
            if(Record >= _CreateSaveFiles._RecordsArray.Records[i])
            {
                    LastIndex = i;
            }
        }
        for(int i = 0; i < LastIndex; ++i)
        {
            _CreateSaveFiles._RecordsArray.Records[i] = _CreateSaveFiles._RecordsArray.Records[i+1];
        }

        _CreateSaveFiles._RecordsArray.Records[LastIndex] = Record;
        File.WriteAllText(_CreateSaveFiles._PathForRecords, JsonUtility.ToJson(_CreateSaveFiles._RecordsArray, true));
    }

    public void SaveSoundSettings(float Volume)
    {
        _CreateSaveFiles._RecordsSettings.SoundsVolume = Volume;
        File.WriteAllText(_CreateSaveFiles._PathForSettings, JsonUtility.ToJson(_CreateSaveFiles._RecordsSettings, true));
    }

    public void SaveMusicSettings(float Volume)
    {
        _CreateSaveFiles._RecordsSettings.MusicVolume = Volume;
        File.WriteAllText(_CreateSaveFiles._PathForSettings, JsonUtility.ToJson(_CreateSaveFiles._RecordsSettings, true));
    }

    public void SaveChousenControlType(int NumberOfConfiguration)
    {
        _CreateSaveFiles._RecordsSettings.TypeOfControl = NumberOfConfiguration;
        File.WriteAllText(_CreateSaveFiles._PathForSettings, JsonUtility.ToJson(_CreateSaveFiles._RecordsSettings, true));
    }
}

