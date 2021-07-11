using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOfWeekElement : MonoBehaviour
{
    [SerializeField] private Color _colorSelected;
    [SerializeField] private Color _colorDeselected;

    [SerializeField] private Toggle _toggle;

    [SerializeField] private Text _nameDayOFWeekText;
    [SerializeField] private GameObject _checkmarkObject;

    public Toggle Toggle => _toggle;

    private void Selected(int indexDayOfWeek)
    {
        _nameDayOFWeekText.color = _colorSelected;
        _checkmarkObject.SetActive(true);
        _toggle.isOn = true;

        Menu.Instance.AllParameters.SelectedDaysOfWeek[indexDayOfWeek] = true;
        Menu.Instance.AllParameters.SaveToFile();
    }
    private void Deselected(int indexDayOfWeek)
    {
        _nameDayOFWeekText.color = _colorDeselected;
        _checkmarkObject.SetActive(false);
        _toggle.isOn = false;

        Menu.Instance.AllParameters.SelectedDaysOfWeek[indexDayOfWeek] = false;
        Menu.Instance.AllParameters.SaveToFile();
    }

    public void ValueChanged(bool flag, int indexDayOfWeek)
    {
        if(flag)
        {
            Selected(indexDayOfWeek);
        }
        else
        {
            Deselected(indexDayOfWeek);
        }
    }
}
