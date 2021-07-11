using DG.Tweening;
using UnityEngine;

public class PanelInformation : MonoBehaviour
{
    [SerializeField] private string namePanel;
    [SerializeField] private RectTransform[] childPanels;
    [SerializeField] private SwipeOpenAndClosePanel[] childSwipePanels;
    [SerializeField] private RectTransform[] scrollBarContents;

    public string Name => namePanel;

    public void Reset()
    {
        foreach (var item in childPanels)
        {
            item.DOAnchorPosX(item.rect.width, 0.4f);
        }
        foreach (var item in childSwipePanels)
        {
            item.Hide();
        }
        foreach (var item in scrollBarContents)
        {
            item.anchoredPosition = Vector2.zero;
        }
    }
}
