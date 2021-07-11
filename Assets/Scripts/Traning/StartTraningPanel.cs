using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartTraningPanel : HideAndShowPanel
{
    [SerializeField] private GameObject addingTimeObject;

    [SerializeField] private SpawnerTraningDay spawnerTraningDay;

    [SerializeField] private Text stopwatchText;
    [SerializeField] private ViewWorkoutPanel viewWorkout;

    [SerializeField] private CanvasGroup _restGroup;

    [SerializeField] private Color passedExerciseColor;
    [SerializeField] private Color unpassedExerciseColor;

    [SerializeField] private Image[] checkPoints;

    [Header("Active")]
    [SerializeField] private CanvasGroup _traningGroup;

    [SerializeField] private Image _currentExerciseImage;

    [SerializeField] private CanvasGroup _inforamtionAboutCurrentExercise;
    [SerializeField] private Text _nameCurrentExercise;
    [SerializeField] private Text _descriptionCurrentExercise;
    [SerializeField] private RectTransform _informationContent;

    [SerializeField] private Text _nameCurrentExerciseText;
    [SerializeField] private Text _repetitionsCurrentExerciseText;


    [System.Serializable]
    private struct NextExercise
    {
        public Image Icon;
        public Text Name;
        public Text CountRepetitions;
    }

    [SerializeField] private NextExercise nextExercise;

    private bool isTimerOn = false;
    private bool isTimerPause = false;
    private bool isStartAnimation = false;

    private int numberCurrentExercise = 0;

    private int time;
    private int startTime = 30;
    private int addTime = 15;

    private float second = 0;
    private float _animationDuration = 0.3f;

    private void Update()
    {
        if(isTimerOn && !isTimerPause)
        {
            second += Time.deltaTime;
            if(second >= 1f)
            {
                time -= 1;
                second = 0;
                stopwatchText.text = time.ToString();
                if(time == 0)
                {
                    ShowTraning();
                }
            }
        }
    }

    public override void Show(int i)
    {
        base.Show(i);
        ShowTraning();

        numberCurrentExercise = 0;
        SetNextExercise();

        for (int j = 0; j < checkPoints.Length; j++)
        {
            checkPoints[j].color = unpassedExerciseColor;
        }

        _currentExerciseImage.sprite = viewWorkout.SelectedHints[numberCurrentExercise].ImagesForAnimation[0];
        _nameCurrentExerciseText.text = viewWorkout.SelectedHints[numberCurrentExercise].NameExercise;
        _repetitionsCurrentExerciseText.text = SpawnerExcercisePanel.SetRepetition(viewWorkout.SelectedHints[numberCurrentExercise]);

        ContinueTime();
        StartTime();
    }

    public override void Hide()
    {
        isStartAnimation = false;
        base.Hide();
        StopTime();
    }
    public void AddingTime()
    {
        time += addTime;
        stopwatchText.text = time.ToString();
        addingTimeObject.SetActive(false);
    }

    public void StartTraning()
    {
        ShowTraning();
    }

    public void ReadyExercise()
    {
        isStartAnimation = false;
        StopCoroutine(PlayerAnimtionHint());

        checkPoints[numberCurrentExercise].color = passedExerciseColor;

        numberCurrentExercise++;

        isTimerPause = false;

        if(numberCurrentExercise >= checkPoints.Length)
        {
            viewWorkout.Hide();
            Hide();

            spawnerTraningDay.AllSpawnElements[Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning]].Button.interactable = false;
            Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning] += 1;
            if(Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning] < 30)
                spawnerTraningDay.AllSpawnElements[Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning]].Button.interactable = true;

            Menu.Instance.AllParameters.DaysPassed[TemporaryVariables.IndexSelectedTraning].Passeds[TemporaryVariables.IndexSelectedDay] = true;
            spawnerTraningDay.CheckingTraningBlockPassed(TemporaryVariables.IndexSelectedTraning);
            Menu.Instance.AllParameters.SaveToFile();
            spawnerTraningDay.AppearanceChanges();
        }
        else
        {
            StartTime();
            SetNextExercise();
        }

        ShowRest();
    }

    public void PauseOrContinueTime()
    {
        if (isTimerPause)
        {
            ContinueTime();
        }
        else
        {
            PauseTime();
        }
    }

    public void OpenInforamtionAboutCurrentExercise()
    {
        _nameCurrentExercise.text = viewWorkout.SelectedHints[numberCurrentExercise].NameExercise;
        _descriptionCurrentExercise.text = viewWorkout.SelectedHints[numberCurrentExercise].ExerciseDescription;

        _inforamtionAboutCurrentExercise.DOFade(1, _animationDuration)
                                            .OnStart(() =>
                                            {
                                                _inforamtionAboutCurrentExercise.blocksRaycasts = true;
                                            })
                                            .OnUpdate(() => _informationContent.sizeDelta = Vector2.zero);

    }
    public void CloseInforamtionAboutCurrentExercise()
    {
        _inforamtionAboutCurrentExercise.DOFade(0, _animationDuration)
                                               .OnComplete(() =>
                                               {
                                                   _inforamtionAboutCurrentExercise.blocksRaycasts = false;
                                               });
    }

    private void ShowTraning()
    {
        _restGroup.DOFade(0, _animationDuration)
            .OnStart(() =>
            {
                _restGroup.blocksRaycasts = false;
            });

        _traningGroup.DOFade(1, _animationDuration)
            .OnComplete(() =>
            {
                _traningGroup.blocksRaycasts = true;
                isStartAnimation = true;
                StartCoroutine(PlayerAnimtionHint());
            });

        StopTime();
    }
    private void ShowRest()
    {
        addingTimeObject.SetActive(true);

        _traningGroup.DOFade(0, _animationDuration)
            .OnStart(() =>
            {
                _traningGroup.blocksRaycasts = false;
            });

        _restGroup.DOFade(1, _animationDuration)
            .OnComplete(() =>
            {
                _restGroup.blocksRaycasts = true;
                _currentExerciseImage.sprite = viewWorkout.SelectedHints[numberCurrentExercise].ImagesForAnimation[0];
                _nameCurrentExerciseText.text = viewWorkout.SelectedHints[numberCurrentExercise].NameExercise;
                _repetitionsCurrentExerciseText.text = SpawnerExcercisePanel.SetRepetition(viewWorkout.SelectedHints[numberCurrentExercise]);
            });
    }

    private void StartTime()
    {
        time = startTime;
        stopwatchText.text = time.ToString();

        isTimerOn = true;
    }

    private void StopTime()
    {
        isTimerOn = false;
    }

    private void PauseTime()
    {
        isTimerPause = true;
    }

    private void ContinueTime()
    {
        isTimerPause = false;
    }
    private void SetNextExercise()
    {
        nextExercise.Icon.sprite = viewWorkout.SelectedHints[numberCurrentExercise].ImagesForAnimation[0];
        nextExercise.Name.text = viewWorkout.SelectedHints[numberCurrentExercise].NameExercise;
        nextExercise.CountRepetitions.text = SpawnerExcercisePanel.SetRepetition(viewWorkout.SelectedHints[numberCurrentExercise]);
    }
    private IEnumerator PlayerAnimtionHint()
    {
        if (viewWorkout.SelectedHints.Length > 1)
        {
            int i = 0;

            while (isStartAnimation)
            {
                _currentExerciseImage.sprite = viewWorkout.SelectedHints[numberCurrentExercise].ImagesForAnimation[i];
                i++;
                if (i >= viewWorkout.SelectedHints[numberCurrentExercise].ImagesForAnimation.Length)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
