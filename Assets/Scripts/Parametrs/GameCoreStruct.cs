
[System.Serializable]
public struct GameCoreStruct
{
    public int[] CurrentDayTranings;
    public int[] LevelCurrentTranings;

    public string HumanName;
    public string HumanHeight;

    public HumanAnthropometry AnthropometryBeforeTraining;
    public HumanAnthropometry AnthropometryAfterTraining;

    public bool IsPremiumOpen;

    public bool IsTurnOnReminders;
    public string NotificationTime;
    public bool[] SelectedDaysOfWeek;
    public Days[] DaysPassed;
}

[System.Serializable]
public struct Days
{
    public bool[] Passeds;
}
