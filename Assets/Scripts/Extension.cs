using System;
using UnityEngine.UI;

public static class Extension
{
    public static void ShowPanel(this Button button, int index, Action<int> Show)
    {
        button.onClick.AddListener(delegate () {
            Show(index);
        });
    }
    public static void ShowPanel(this Button button, Action Show)
    {
        button.onClick.AddListener(delegate () {
            Show();
        });
    }

    public static void SelectedOrDeselectedDayOfWeek(this Toggle toggle, int indexDayOfWeek, Action<bool, int> onValueChanged)
    {
        toggle.onValueChanged.AddListener((isOn) =>
        {
            onValueChanged(isOn, indexDayOfWeek);
        });
    }


    public static void RemoveShowPanel(this Button button, int index, Action<int> Show)
    {
        button.onClick.RemoveListener(delegate () {
            Show(index);
        });
    }
    public static void RemoveShowPanel(this Button button, Action Show)
    {
        button.onClick.RemoveListener(delegate () {
            Show();
        });
    }
}
