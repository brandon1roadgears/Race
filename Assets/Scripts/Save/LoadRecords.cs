using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Structs;

public class LoadRecords : MonoBehaviour
{
    [SerializeField] Text [] Records = new Text[10];
    RecordsArray _RecordsArray;
    RecordsSettings _RecordsSettings;
    private string _PathForRecords = "";
    private string _PathForSettings = "";
    void Start()
    {
        #if  UNITY_ANDROID && !UNITY_EDITOR
            _PathForRecords = Path.Combine(Application.persistentDataPath, "SaveRecords.json");
            _PathForSettings = Path.Combine(Application.persistentDataPath, "SaveSettings.json");
        #else
            _PathForRecords = Path.Combine(Application.dataPath, "SaveRecords.json");
            _PathForSettings = Path.Combine(Application.dataPath, "SaveSettings.json");
        #endif

        if(File.Exists(_PathForRecords))
        {
            _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_PathForRecords));
            for(int i = 9; i > -1; --i)
            {
                if(_RecordsArray.Records[i] != -1)
                {
                    Records[9 - i].text = _RecordsArray.Records[i].ToString();
                }
            }
        }
        else
        {
            _RecordsArray = new RecordsArray{};
            _RecordsArray.Records = new int[10] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
            File.WriteAllText(_PathForRecords, JsonUtility.ToJson(_RecordsArray, true));
        }

        if(File.Exists(_PathForSettings))
        {
            _RecordsSettings = JsonUtility.FromJson<RecordsSettings>(File.ReadAllText(_PathForSettings));
        }
        else
        {
            _RecordsSettings = new RecordsSettings{};
            _RecordsSettings.MusicVolume = 1.0f;
            _RecordsSettings.SoundsVolume = 1.0f;
            _RecordsSettings.TypeOfControl = 1;
            File.WriteAllText(_PathForSettings, JsonUtility.ToJson(_RecordsSettings, true));
        }
    }
} 
