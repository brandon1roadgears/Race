using UnityEngine;
using System.IO;
using Structs;

public class CreateSaveFiles : MonoBehaviour
{
    private string FileForRecords = "SaveRecords.json", FileForSettings = "SaveSettings.json";
    internal string _PathForSettings = "", _PathForRecords = "";
    internal RecordsArray _RecordsArray;
    internal RecordsSettings _RecordsSettings;


    private void Awake()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            _PathForRecords = Path.Combine(Application.persistentDataPath, FileForRecords);
            _PathForSettings = Path.Combine(Application.persistentDataPath, FileForSettings);
        #else
            _PathForRecords = Path.Combine(Application.dataPath, FileForRecords);
            _PathForSettings = Path.Combine(Application.dataPath, FileForSettings);
        #endif

        if(!File.Exists(_PathForRecords))
        {
            _RecordsArray = new RecordsArray
            {
                Records = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            File.WriteAllText(_PathForRecords, JsonUtility.ToJson(_RecordsArray, true));
        }
        else
        {
            _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_PathForRecords));
        }

        if(!File.Exists(_PathForSettings))
        {
            _RecordsSettings = new RecordsSettings
            {
                TypeOfControl = 0,
                MusicVolume = 1.0f,
                SoundsVolume = 1.0f,
                isPostProcessing = false
            };
            File.WriteAllText(_PathForSettings, JsonUtility.ToJson(_RecordsSettings, true));
        }
        else
        {
            _RecordsSettings = JsonUtility.FromJson<RecordsSettings>(File.ReadAllText(_PathForSettings));
        }
    }
}
