using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExercisePanel : MonoBehaviour
{
    [SerializeField] private Image iconExercise;
    [SerializeField] private Button button;
    [SerializeField] private Text nameText;
    [SerializeField] private Text numberRepetitionsText;

    public Image IconExercise => iconExercise;
    public Button Button => button;
    public Text NameText => nameText;
    public Text NumberRepetitionsText => numberRepetitionsText;

}
