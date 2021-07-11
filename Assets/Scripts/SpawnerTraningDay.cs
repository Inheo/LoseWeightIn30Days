using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerTraningDay : MonoBehaviour
{
    [SerializeField] private TraningDayElement traningDayPrefab;

    [SerializeField] private Transform parent;

    [SerializeField] private int count;

    [SerializeField] private ViewWorkoutPanel viewWorkoutPanel;
    [SerializeField] private TraningDaysPanel traningDaysPanel;
    [SerializeField] private Traning traningPanel;


    private List<TraningDayElement> allSpawnElements = new List<TraningDayElement>();

    public List<TraningDayElement> AllSpawnElements => allSpawnElements;

    private void Start()
    {
        Spawn();
        MakingAnInAppPurchase.Instance.OnPurchaseComplete += Refresh;
    }

    private void Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            TraningDayElement traningDay = Instantiate(traningDayPrefab, parent);
            traningDay.CurrentDayText.text = $"{i + 1} Δενό";
            if(i >= 3 && !Menu.Instance.AllParameters.IsPremiumOpen)
            {
                traningDay.Button.ShowPanel(traningPanel.ShowBuyAccessPanel);
            }
            else
            {
                traningDay.Button.ShowPanel(i, viewWorkoutPanel.Show);
            }


            allSpawnElements.Add(traningDay);
        }
    }

    public void AppearanceChanges()
    {
        traningDaysPanel.ChangeLeftDays();
        for (int i = 0; i < count; i++)
        {
            if (Menu.Instance.AllParameters.DaysPassed[TemporaryVariables.IndexSelectedTraning].Passeds[i])
            {
                allSpawnElements[i].Background.sprite = allSpawnElements[i].BgForPassedDay;
                allSpawnElements[i].CurrentDayText.color = allSpawnElements[i].FontColorForPassedDay;
                allSpawnElements[i].ReadymarkObject.SetActive(true);
            }
            else
            {
                allSpawnElements[i].Background.sprite = allSpawnElements[i].BgForUnpassedDay;
                allSpawnElements[i].CurrentDayText.color = allSpawnElements[i].FontColorForUnpassedDay;
                allSpawnElements[i].ReadymarkObject.SetActive(false);
            }

            SetCurrentTraningDay(i);
        }
    }

    public void SetCurrentTraningDay(int i)
    {
        if (i == Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning])
        {
            allSpawnElements[i].Button.interactable = true;
        }
        else
        {
            allSpawnElements[i].Button.interactable = false;
        }

    }

    public void Refresh()
    {
        for (int i = 0; i < count; i++)
        {
            if (i >= 4 && !Menu.Instance.AllParameters.IsPremiumOpen)
            {
                allSpawnElements[i].Button.onClick.RemoveAllListeners();
                allSpawnElements[i].Button.ShowPanel(traningPanel.ShowBuyAccessPanel);
            }
            else
            {
                allSpawnElements[i].Button.onClick.RemoveAllListeners();
                allSpawnElements[i].Button.ShowPanel(i, viewWorkoutPanel.Show);
            }
        }
    }

    public void CheckingTraningBlockPassed(int index)
    {
        if(Menu.Instance.AllParameters.CurrentDayTranings[index] >= 30)
        {
            Menu.Instance.AllParameters.CurrentDayTranings[index] = 0;

            for (int i = 0; i < Menu.Instance.AllParameters.DaysPassed[index].Passeds.Length; i++)
            {
                Menu.Instance.AllParameters.DaysPassed[index].Passeds[i] = false;
            }
        }
    }
}
