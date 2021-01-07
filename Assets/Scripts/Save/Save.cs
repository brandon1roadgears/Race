using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Structs;

public class Save : MonoBehaviour
{    

    private string _Path = "";
    RecordsArray _RecordsArray;

    private void Awake()
    {
        #if  UNITY_ANDROID && !UNITY_EDITOR
            _Path = Path.Combine(Application.persistentDataPath, "Save.json");
        #else
            _Path = Path.Combine(Application.dataPath, "Save.json");
        #endif
    }
    private void Start()
    {
        if(File.Exists(_Path))
        {
            _RecordsArray = JsonUtility.FromJson<RecordsArray>(File.ReadAllText(_Path));
        }
        else
        {
            _RecordsArray = new RecordsArray{};
            _RecordsArray.Records = new int[10] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
        }

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
        File.WriteAllText(_Path, JsonUtility.ToJson(_RecordsArray, true));
    }
}

