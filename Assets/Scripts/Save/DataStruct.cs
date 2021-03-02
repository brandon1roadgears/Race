namespace Structs
{
    [System.Serializable] public struct RecordsArray
    {
        public int[]  Records;
    }
    [System.Serializable] public struct RecordsSettings
    {
            public int TypeOfControl;
            public float MusicVolume;
            public float SoundsVolume;
            public bool isPostProcessing;
    }
}