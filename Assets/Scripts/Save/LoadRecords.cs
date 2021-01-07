using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Structs;

public class LoadRecords : MonoBehaviour
{
    [SerializeField] Text [] Records = new Text[10];
    RecordsArray _RecordsArray;
    private string _Path = "";
    void Start()
    {
         #if  UNITY_ANDROID && !UNITY_EDITOR
            _Path = Path.Combine(Application.persistentDataPath, "Save.json");
        #else
            _Path = Path.Combine(Application.dataPath, "Save.json");
        #endif

        if(!File.Exists(_Path))
        {
            return;
        }
        _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_Path));
        for(int i = 9; i > -1; --i)
        {
            if(_RecordsArray.Records[i] != -1)
            {
                Records[9 - i].text = _RecordsArray.Records[i].ToString();
            }
        }
    }
} 
