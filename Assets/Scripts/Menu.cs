using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    [SerializeField] private SwipeOpenAndClosePanel burgerMenu;

    [SerializeField] private PanelInformation traningPanel;

    [SerializeField] private Text activePanelName;

    private PanelInformation lastOpenPanel;

    public LongTermParameters AllParameters = new LongTermParameters();

    public static Menu Instance;

    public DateTime date;
    public int dayOfWeek;

    private void Awake()
    {
        Instance = this;
        AllParameters.LoadFromFile();
        OpenPanel(traningPanel);

        date = DateTime.Now;
        dayOfWeek = (int)date.DayOfWeek;
        DateTime dateTime = DateTime.Parse("20.06.2021 22:30");
        Debug.Log(dateTime + " " + dateTime.DayOfWeek);
    }

    public void OpenPanel(PanelInformation panel)
    {
        lastOpenPanel?.gameObject.SetActive(false);
        lastOpenPanel?.Reset();

        activePanelName.text = panel.Name;

        panel.gameObject.SetActive(true);
        panel.Reset();

        lastOpenPanel = panel;

        burgerMenu.Hide();
    }

    private void OnApplicationQuit()
    {
        AllParameters.SaveToFile();
    }

    private void OnApplicationPause(bool pause)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AllParameters.SaveToFile();
        }
    }
}
