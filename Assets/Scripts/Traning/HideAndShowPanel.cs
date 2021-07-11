using DG.Tweening;
using UnityEngine;

public abstract class HideAndShowPanel : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;

    public virtual void Show( int i)
    {
        rectTransform.DOAnchorPosX(0, 0.4f);
    }

    public virtual void Hide()
    {
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0.4f);
    }
}
