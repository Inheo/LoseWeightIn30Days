using UnityEngine;
using Unity.Notifications.Android;
using System;

public class PushNotification
{
    public void Initialize()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "Напоминание о тренировках",
            Description = "Напоминания о том, что пора на тренировку",
            Id = "traning",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification()
    {
        AndroidNotificationCenter.CancelAllNotifications();

        DateTime dateTime = DateTime.Parse($"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year} {Menu.Instance.AllParameters.NotificationTime}");

        int addingDay = FindNextSelectedDayOfWeek((int)dateTime.DayOfWeek);

        if (addingDay >= 0 && !string.IsNullOrWhiteSpace(Menu.Instance.AllParameters.NotificationTime))
        {
            for (int i = 0; i < 30; i++)
            {
                dateTime = dateTime.AddDays(addingDay);

                dateTime = DateTime.Parse($"{dateTime.Day}.{dateTime.Month}.{dateTime.Year} {Menu.Instance.AllParameters.NotificationTime}");

                Debug.Log($"Schedule day of week: {dateTime}");

                AndroidNotification notification = new AndroidNotification()
                {
                    Title = "Пора на тренировку",
                    Text = "Время пришло, пора на тренировку",
                    FireTime = dateTime
                };

                AndroidNotificationCenter.SendNotification(notification, "traning");

                addingDay = FindNextSelectedDayOfWeek((int)dateTime.DayOfWeek + 1, 1);
            }
        }
    }

    public void TurnOff()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }

    private int FindNextSelectedDayOfWeek(int dayOfWeek, int offset = 0)
    {
        if (FindScheduleDayOfWeek())
        {
            int dayForAdding = 0 + offset;

            for (int i = 0; i < Menu.Instance.AllParameters.SelectedDaysOfWeek.Length; i++)
            {
                dayOfWeek = dayOfWeek >= Menu.Instance.AllParameters.SelectedDaysOfWeek.Length ? 0 : dayOfWeek;

                if (!Menu.Instance.AllParameters.SelectedDaysOfWeek[dayOfWeek])
                {
                    dayForAdding++;
                }
                else
                {
                    return dayForAdding;
                }
                dayOfWeek++;
            }

            return dayForAdding;
        }
        else
        {
            return -1;
        }

    }

    private bool FindScheduleDayOfWeek()
    {
        for (int i = 0; i < Menu.Instance.AllParameters.SelectedDaysOfWeek.Length; i++)
        {
            if (Menu.Instance.AllParameters.SelectedDaysOfWeek[i])
            {
                return true;
            }
        }

        return false;
    }

}
