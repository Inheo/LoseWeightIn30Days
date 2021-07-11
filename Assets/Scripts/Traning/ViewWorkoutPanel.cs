using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViewWorkoutPanel : HideAndShowPanel
{
    [SerializeField] private CanvasGroup informationPosePanel;
    [SerializeField] private RectTransform informationContent;
    [SerializeField] private RectTransform exerciseContent;

    [SerializeField] private Traning traning;
    [SerializeField] private InformationPosePanel informationPanel;
    [SerializeField] private SpawnerExcercisePanel spawnerExcercisePanel;

    [SerializeField] private Text currentDayText;
    [SerializeField] private Image background;

    [SerializeField] private Image yourLevelImage;
    [SerializeField] private Sprite[] levels;

    [SerializeField] private Sprite[] backgroundIcons;

    #region Hint
    [System.Serializable] public struct Hint
    {
        public string NameExercise;
        public Sprite[] ImagesForAnimation;
        [TextArea] public string ExerciseDescription;
    }

    [System.Serializable] public struct HintsForAllPanel
    {
        public string NameSelectedTraning;
        public Hint[] Hints;
    }

    [SerializeField] private HintsForAllPanel[] hintsForAllPanels;
    #endregion

    private Hint[] selectedHints;

    private int _indexSelectedHint;
    private bool isStartAnimation;

    private Menu menu;

    public Hint[] SelectedHints => selectedHints;

    public override void Show(int i)
    {
        menu = Menu.Instance;

        TemporaryVariables.IndexSelectedDay = i;

        background.sprite = backgroundIcons[TemporaryVariables.IndexSelectedTraning];

        yourLevelImage.sprite = levels[menu.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]];

        currentDayText.text = $"{i + 1} Δενό";

        selectedHints = spawnerExcercisePanel.Spawn(i, hintsForAllPanels[TemporaryVariables.IndexSelectedTraning].Hints, ShowInformationPosePanel);

        ChangeInformationAboutLevel();

        base.Show(i);
    }

    public override void Hide()
    {
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0.4f)
            .OnUpdate(() =>
            {
                exerciseContent.anchoredPosition = Vector2.zero;
                traning.SetCurrentDayForTexts();
            });

    }

    public void ChangeLevel()
    {
        menu.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]++;

        if (menu.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]
            >=
            menu.AllParameters.MAX_LEVEL_TRANINGS[TemporaryVariables.IndexSelectedTraning])
        {
            menu.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning] = 0;
        }

        ChangeInformationAboutLevel();
    }

    public void ShowInformationPosePanel(int i)
    {
        _indexSelectedHint = i;

        if(selectedHints[i].ImagesForAnimation.Length > 1)
            informationPanel.PlayAnimationHint.SetActive(true);
        else
            informationPanel.PlayAnimationHint.SetActive(false);

        informationPanel.NamePose.text = selectedHints[i].NameExercise;
        informationPanel.HintImage.sprite = selectedHints[i].ImagesForAnimation[0];
        informationPanel.HintText.text = selectedHints[i].ExerciseDescription;


        informationPosePanel.DOFade(1, 0.5f)
            .OnStart(() =>
            {
                informationPosePanel.blocksRaycasts = true;
            })
            .OnUpdate(() =>
            {
                informationContent.sizeDelta = Vector2.zero;
            });
    }


    public void HideInformationPosePanel()
    {
        isStartAnimation = false;
        informationPosePanel.DOFade(0, 0.5f)
            .OnStart(() =>
            {
                informationPosePanel.blocksRaycasts = false;
            });

        informationContent.anchoredPosition = Vector3.zero;
    }

    public void PlayAnimationHint()
    {
        isStartAnimation = true;
        informationPanel.PlayAnimationHint.SetActive(false);
        StartCoroutine(PlayerAnimtionHint());
    }

    private void ChangeInformationAboutLevel()
    {
        yourLevelImage.sprite = levels[menu.AllParameters.LevelCurrentTranings[TemporaryVariables.IndexSelectedTraning]];

        spawnerExcercisePanel.ChangeLevel(hintsForAllPanels[TemporaryVariables.IndexSelectedTraning].Hints);

        traning.ChangeLevelTextName();
    }

    private IEnumerator PlayerAnimtionHint()
    {
        if (selectedHints.Length > 1)
        {
            int i = 1;

            while (isStartAnimation)
            {
                informationPanel.HintImage.sprite = selectedHints[_indexSelectedHint].ImagesForAnimation[i];
                i++;
                if (i >= selectedHints[_indexSelectedHint].ImagesForAnimation.Length)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
