using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Structs;

public class LoadRecords : MonoBehaviour
{
    [SerializeField] Text [] Records = new Text[10];
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundSlider;
    [SerializeField] private GameObject[] ChousenConfiguration = new GameObject[8]; 
    private RecordsSettings _RecordsSettings;
    private RecordsArray _RecordsArray;
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
            _RecordsArray.Records = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            File.WriteAllText(_PathForRecords, JsonUtility.ToJson(_RecordsArray, true));
        }

        if(File.Exists(_PathForSettings))
        {
            _RecordsSettings = JsonUtility.FromJson<RecordsSettings>(File.ReadAllText(_PathForSettings));
            MusicSlider.value = _RecordsSettings.MusicVolume;
            SoundSlider.value = _RecordsSettings.SoundsVolume;
            ChousenConfiguration[0].SetActive(false);
            ChousenConfiguration[_RecordsSettings.TypeOfControl].SetActive(true);
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
