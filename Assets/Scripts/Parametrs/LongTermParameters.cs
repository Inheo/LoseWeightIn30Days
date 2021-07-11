using System;
using System.IO;
using UnityEngine;

public class LongTermParameters
{
    public const string KEY = "LongTermParameters";
    public readonly int[] MAX_LEVEL_TRANINGS = new int[4] { 3, 3, 3, 3 };

    public int[] CurrentDayTranings = new int[] { 0, 0, 0, 0 };
    public int[] LevelCurrentTranings = new int[] { 0, 0, 0, 0 };

    public string HumanName = "";
    public string HumanHeight = "";

    public HumanAnthropometry AnthropometryBeforeTraining = new HumanAnthropometry()
    {
        Weight = "",
        Chest = "",
        Waist = "",
        Thighs = ""
    };
    public HumanAnthropometry AnthropometryAfterTraining = new HumanAnthropometry()
    {
        Weight = "",
        Chest = "",
        Waist = "",
        Thighs = ""
    };

    public bool IsPremiumOpen = false;

    public bool IsTurnOnReminders = false;
    public string NotificationTime = "";
    public bool[] SelectedDaysOfWeek = new bool[7] { false, false, false, false, false, false, false };
    public Days[] DaysPassed = new Days[4] 
    { 
        new Days { Passeds = new bool[30] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false} } ,   
        new Days { Passeds = new bool[30] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false} } ,   
        new Days { Passeds = new bool[30] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false} } ,   
        new Days { Passeds = new bool[30] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false} }    
    };


    private string savePath;
    private string saveFileName = "data.json";

    public void SaveToFile()
    {
        GameCoreStruct gameCore = new GameCoreStruct
        {
            CurrentDayTranings = this.CurrentDayTranings,
            LevelCurrentTranings = this.LevelCurrentTranings,

            HumanName = this.HumanName,
            HumanHeight = this.HumanHeight,

            AnthropometryBeforeTraining = this.AnthropometryBeforeTraining,
            AnthropometryAfterTraining = this.AnthropometryAfterTraining,

            IsPremiumOpen = this.IsPremiumOpen,

            IsTurnOnReminders = this.IsTurnOnReminders,
            NotificationTime = this.NotificationTime,
            SelectedDaysOfWeek = this.SelectedDaysOfWeek,
            DaysPassed = this.DaysPassed
        };

        string json = JsonUtility.ToJson(gameCore, true);

        try
        {
            File.WriteAllText(savePath, json);
        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} => [GameCore] - (<color=red>Error</color>) - SaveToFile -> " + e.Message);
        }
    }

    public void LoadFromFile()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            savePath = Path.Combine(Application.persistentDataPath, saveFileName);
#else
        savePath = Path.Combine(Application.dataPath, saveFileName);
#endif

        Debug.Log("savePAth: " + savePath);

        if (!File.Exists(savePath))
        {
            Debug.Log("{GameLog} => [GameCore] - LoadFromFile -> File Not Found!");
            return;
        }

        try
        {
            string json = File.ReadAllText(savePath);

            GameCoreStruct gameCoreFromJson = JsonUtility.FromJson<GameCoreStruct>(json);

            this.CurrentDayTranings = gameCoreFromJson.CurrentDayTranings;
            this.LevelCurrentTranings = gameCoreFromJson.LevelCurrentTranings;
            this.HumanName = gameCoreFromJson.HumanName;
            this.HumanHeight = gameCoreFromJson.HumanHeight;
            this.AnthropometryAfterTraining = gameCoreFromJson.AnthropometryAfterTraining;
            this.AnthropometryBeforeTraining = gameCoreFromJson.AnthropometryBeforeTraining;

            this.IsPremiumOpen = gameCoreFromJson.IsPremiumOpen;

            this.IsTurnOnReminders = gameCoreFromJson.IsTurnOnReminders;
            this.NotificationTime = gameCoreFromJson.NotificationTime;
            this.SelectedDaysOfWeek = gameCoreFromJson.SelectedDaysOfWeek;
            this.DaysPassed = gameCoreFromJson.DaysPassed;

        }
        catch (Exception e)
        {
            Debug.Log("{GameLog} - [GameCore] - (<color=red>Error</color>) - LoadFromFile -> " + e.Message);
        }
    }
}
