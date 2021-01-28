using UnityEngine;
using System.IO;
using Structs;

public class Save : MonoBehaviour
{    
    private string _PathForRecords = "";
    private string _PathForSettings = "";
    RecordsArray _RecordsArray;
    RecordsSettings _RecordsSettings;

    private void Awake()
    {
        #if  UNITY_ANDROID && !UNITY_EDITOR
            _PathForRecords = Path.Combine(Application.persistentDataPath, "SaveRecords.json");
            _PathForSettings = Path.Combine(Application.persistentDataPath, "SaveSettings.json");
        #else
            _PathForRecords = Path.Combine(Application.dataPath, "SaveRecords.json");
            _PathForSettings = Path.Combine(Application.dataPath, "SaveSettings.json");
        #endif
        
        _RecordsSettings = JsonUtility.FromJson<RecordsSettings>(File.ReadAllText(_PathForSettings));
        _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_PathForRecords));
    }
    internal void SaveResult(int Record)
    {
        int LastIndex = 0;
        for(int i = 0; i < 10; ++i)
        {
            if(Record >= _RecordsArray.Records[i])
            {
                    LastIndex = i;
            }
        }
        for(int i = 0; i < LastIndex; ++i)
        {
            _RecordsArray.Records[i] = _RecordsArray.Records[i+1];
        }

        _RecordsArray.Records[LastIndex] = Record;
        File.WriteAllText(_PathForRecords, JsonUtility.ToJson(_RecordsArray, true));
    }

    public void SaveSoundSettings(float Volume)
    {
        _RecordsSettings.SoundsVolume = Volume;
        File.WriteAllText(_PathForSettings, JsonUtility.ToJson(_RecordsSettings, true));
    }

    public void SaveMusicSettings(float Volume)
    {
        _RecordsSettings.MusicVolume = Volume;
        File.WriteAllText(_PathForSettings, JsonUtility.ToJson(_RecordsSettings, true));
    }
}

