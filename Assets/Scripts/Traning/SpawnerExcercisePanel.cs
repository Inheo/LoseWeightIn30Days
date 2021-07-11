using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExcercisePanel : MonoBehaviour
{
    [SerializeField] private ExercisePanel prefab;
    [SerializeField] private Transform parent;

    private List<ExercisePanel> allSpawnPanel = new List<ExercisePanel>();
    private ViewWorkoutPanel.Hint[] spawnedHints;

    private int countSpawnedPrefab = 10;

    public ViewWorkoutPanel.Hint[] Spawn(int day, ViewWorkoutPanel.Hint[] hints, Action<int> action)
    {
        spawnedHints = new ViewWorkoutPanel.Hint[countSpawnedPrefab];

        if(day >= countSpawnedPrefab)
        {
            int div = day / hints.Length;
            day -= hints.Length * div;
        }

        int number = day;

        for (int i = allSpawnPanel.Count; i < countSpawnedPrefab; i++)
        {
            allSpawnPanel.Add(Instantiate(prefab, parent));
        }

        for (int i = 0; i < allSpawnPanel.Count; i++)
        {
            allSpawnPanel[i].IconExercise.sprite = hints[number].ImagesForAnimation[0];
            allSpawnPanel[i].Button.ShowPanel(i, action);
            allSpawnPanel[i].NameText.text = hints[number].NameExercise;

            spawnedHints[i] = hints[number];

            number += 1;
            if (number >= hints.Length) number = 0;

            allSpawnPanel[i].NumberRepetitionsText.text = SetRepetition(hints[i]);
        }

        return spawnedHints;
    }

    public void ChangeLevel(ViewWorkoutPanel.Hint[] hints)
    {
        for (int i = 0; i < countSpawnedPrefab; i++)
        {
            allSpawnPanel[i].NumberRepetitionsText.text = SetRepetition(hints[i]);
        }
    }

    public static string SetRepetition(ViewWorkoutPanel.Hint hint)
    {
        int count;

        if(hint.ImagesForAnimation.Length > 1)
        {
            count = TemporaryVariables.REPETITIONS[Menu.Instance.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]];

            return count.ToString() + " раз";
        }
        else
        {
            count = TemporaryVariables.SECONDS[Menu.Instance.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]];

            return count.ToString() + " секунд";
        }
    }
}
