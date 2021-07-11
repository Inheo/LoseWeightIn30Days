using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TraningDaysPanel : HideAndShowPanel
{
    [System.Serializable] private struct HeaderForTraningDaysPanel
    {
        public string NamePanel;
        public Sprite Background;
    }

    [SerializeField] private HeaderForTraningDaysPanel[] _informationsAboutHeader;

    [SerializeField] private Text daysLeftText;

    [SerializeField] private Image background;
    [SerializeField] private Text NamePanel;
    [SerializeField] private RectTransform scrollContent;

    [SerializeField] private SpawnerTraningDay spawnerTraningDay;

    public override void Show(int i)
    {
        TemporaryVariables.IndexSelectedTraning = i;

        spawnerTraningDay.AppearanceChanges();

        background.sprite = _informationsAboutHeader[i].Background;
        NamePanel.text = _informationsAboutHeader[i].NamePanel;

        base.Show(i);
    }

    public override void Hide()
    {
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0.4f)
            .OnUpdate(() => 
            {
                scrollContent.anchoredPosition = Vector2.zero;
            });
    }

    public void ChangeLeftDays()
    {
        int leftDays = 30 - Menu.Instance.AllParameters.CurrentDayTranings[TemporaryVariables.IndexSelectedTraning];
        daysLeftText.text = $"Осталось {leftDays} дней";
    }
}
