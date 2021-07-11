using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SwipeOpenAndClosePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private bool horizontal,
                                    vertical;

    [SerializeField] private Vector2 endPosition;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private RectTransform rectTransformForMoving;
    [SerializeField] private float animationDuration = 0.7f;

    public bool isHide { get; private set; }

    private Vector2 offset = Vector2.zero;

    private void Start()
    {
        Hide();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = (Vector2)Input.mousePosition - rectTransformForMoving.anchoredPosition;
        offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = (Vector2)Input.mousePosition - offset;
        if(horizontal)
        {
            pos.y = transform.position.y;
            if (pos.x >= endPosition.x) pos.x = endPosition.x;
        }
        if(vertical)
        {
            pos.x = transform.position.x;
            if (pos.y >= endPosition.y) pos.y = endPosition.y;
        }

        rectTransformForMoving.anchoredPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 allPath = startPosition - endPosition;

        if(horizontal)
        {
            HideOrShow(rectTransformForMoving.anchoredPosition.x, allPath.x);
        }
        if(vertical)
        {
            HideOrShow(rectTransformForMoving.anchoredPosition.y, allPath.y);
        }
    }

    private void HideOrShow(float rectTransformAxis, float allPathAxis)
    {
        if (Mathf.Abs(rectTransformAxis) >= Mathf.Abs(allPathAxis) * 0.1f)
        {
            if (isHide)
                Show();
            else
                Hide();
        }
        else
        {
            if (isHide)
                Hide();
            else
                Show();
        }
    }

    public void Show()
    {
        isHide = false;
        rectTransformForMoving.DOAnchorPos(endPosition, animationDuration);
    }

    public void Hide()
    {
        isHide = true;
        rectTransformForMoving.DOAnchorPos(startPosition, animationDuration);
    }
}
