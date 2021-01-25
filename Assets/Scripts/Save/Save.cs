using UnityEngine;
using System.IO;
using Structs;

public class Save : MonoBehaviour
{    

    private string _PathForRecords = "";
    RecordsArray _RecordsArray;

    private void Awake()
    {
        #if  UNITY_ANDROID && !UNITY_EDITOR
            _PathForRecords = Path.Combine(Application.persistentDataPath, "SaveRecords.json");
        #else
            _PathForRecords = Path.Combine(Application.dataPath, "SaveRecords.json");
        #endif
    }
    internal void SaveResult(int Record)
    {
        if(File.Exists(_PathForRecords))
        {
            _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_PathForRecords));
        }
        else
        {
            return;
        }
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
}

