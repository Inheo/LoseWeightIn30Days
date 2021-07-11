using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Reminder : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text _selectedTimeText;

    [SerializeField] private Text _selectedNameDayOfWeek;


    [SerializeField] private DayOfWeekElement[] _dayOfWeekElements;

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _unselectedColor;
    [SerializeField] private RectTransform _checkMark;
    [SerializeField] private Text _turnOnText;
    [SerializeField] private Text _turnOffText;

    private PushNotification notification = new PushNotification();

    private string[] _nameDaysOfWeek = new string[7] { "Âñ","Ïí", "Âò", "Ñð", "×ò", "Ïò", "Ñá"};

    private bool isTurnOnReminders;

    private void Start()
    {
        timeText.text = Menu.Instance.AllParameters.NotificationTime;
        _selectedTimeText.text = Menu.Instance.AllParameters.NotificationTime;
        isTurnOnReminders = Menu.Instance.AllParameters.IsTurnOnReminders;

        SetSelectedNameDayOfWeek();

        for (int i = 0; i < _dayOfWeekElements.Length; i++)
        {
            _dayOfWeekElements[i].ValueChanged(Menu.Instance.AllParameters.SelectedDaysOfWeek[i], i);
            _dayOfWeekElements[i].Toggle.SelectedOrDeselectedDayOfWeek(i, SelectDayOfWeek);
        }

        notification.Initialize();

        if(Menu.Instance.AllParameters.IsTurnOnReminders)
        {
            TurnOnReminders();
        }
        else
        {
            TurnOffReminders();
        }
    }

    private void SelectDayOfWeek(bool isOn, int i)
    {
        _dayOfWeekElements[i].ValueChanged(isOn, i);

        SetSelectedNameDayOfWeek();

        if(isTurnOnReminders)
            notification.SendNotification();
    }

    private void SetSelectedNameDayOfWeek()
    {
        _selectedNameDayOfWeek.text = "";

        for (int i = 0; i < Menu.Instance.AllParameters.SelectedDaysOfWeek.Length; i++)
        {
            if (Menu.Instance.AllParameters.SelectedDaysOfWeek[i])
            {
                _selectedNameDayOfWeek.text += "   " + _nameDaysOfWeek[i];
            }
        }
    }

    public void SetTime(string number)
    {
        if (timeText.text.Length < 5)
        {
            if((timeText.text.Length == 0 && int.Parse(number) > 3) || (timeText.text.Length == 2 && int.Parse(number) > 5))
            {
                number = "0" + number;
            }
            if (timeText.text.Length == 2)
            {
                timeText.text += ":";
            }
            timeText.text += number;
        }

        if(timeText.text.Length == 5)
        {
            _selectedTimeText.text = timeText.text;
            Menu.Instance.AllParameters.NotificationTime = timeText.text;
            Menu.Instance.AllParameters.SaveToFile();
            if(isTurnOnReminders)
                notification.SendNotification();
        }
    }

    public void TurnOffReminders()
    {
        _checkMark.DOAnchorPosX(500, 0.3f);

        _turnOffText.color = _selectedColor;
        _turnOnText.color = _unselectedColor;

        isTurnOnReminders = false;
        Menu.Instance.AllParameters.IsTurnOnReminders = false;

        notification.TurnOff();
    }

    public void TurnOnReminders()
    {
        _checkMark.DOAnchorPosX(0, 0.3f);

        _turnOnText.color = _selectedColor;
        _turnOffText.color = _unselectedColor;

        isTurnOnReminders = true;
        Menu.Instance.AllParameters.IsTurnOnReminders = true;

        notification.SendNotification();
    }

    public void Delete()
    {
        if (timeText.text.Length > 0)
        {
            timeText.text = timeText.text.Substring(0, timeText.text.Length - 1);
            if(timeText.text.Length == 3)
            {
                timeText.text = timeText.text.Substring(0, timeText.text.Length - 1);
            }
        }

        if(timeText.text.Length == 0)
        {
            _selectedTimeText.text = timeText.text;
            Menu.Instance.AllParameters.NotificationTime = timeText.text;
            Menu.Instance.AllParameters.SaveToFile();
        }
    }

}
