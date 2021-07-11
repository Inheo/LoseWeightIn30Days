using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeMeal : MonoBehaviour
{
    [SerializeField] private RectTransform _mealsPlanRectTransform;

    [SerializeField] private Text[] _namesOfMeals;
    [SerializeField] private RectTransform[] _rectTransformNamesOfMeals;
    [SerializeField] private RectTransform _checkMark;

    [SerializeField] private float _distanceBetweenPanelsMeals;

    private int _lastSelectedMealsIndex = 0;

    public void ChangeMeals(int i)
    {
        _checkMark.DOAnchorPosX(_rectTransformNamesOfMeals[i].anchoredPosition.x, 0.3f);
        _checkMark.DOSizeDelta(new Vector2(_rectTransformNamesOfMeals[i].sizeDelta.x, _checkMark.sizeDelta.y), 0.3f);

        _lastSelectedMealsIndex = i;

        _mealsPlanRectTransform.DOAnchorPosX(i * _distanceBetweenPanelsMeals * -1, 0.3f);
    }

    #region Swipes
    //[SerializeField] private RectTransform rectTransform;
    //[SerializeField] private float _offsetBetweenChild = 1080;

    //private int _countChild;
    //private static int _direction = 0;

    //private Vector2 _startMousePosition;
    ////private Vector2 _offset;

    //private void Start()
    //{
    //    _countChild = transform.childCount;
    //    _countChild -= 1;
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    _startMousePosition = Input.mousePosition;
    //    //_offset = (Vector2)Input.mousePosition - rectTransform.anchoredPosition;
    //}

    ////public void OnDrag(PointerEventData eventData)
    ////{
    ////    Vector2 pos = new Vector2(Input.mousePosition.x - _offset.x, transform.position.y);

    ////    if (pos.x >= 0) pos.x = 0;
    ////    else if (pos.x <= _offsetBetweenChild * _countChild * -1) pos.x = _offsetBetweenChild * _countChild * -1;


    ////    rectTransform.anchoredPosition = pos;
    ////}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Vector2 endPosition = Input.mousePosition;

    //    if (Mathf.Abs(endPosition.x - _startMousePosition.x) > Mathf.Abs(endPosition.y - _startMousePosition.y))
    //        if (Mathf.Abs((_startMousePosition - endPosition).x) > 100)
    //        {
    //            if (_startMousePosition.x > endPosition.x)
    //            {
    //                _direction++;
    //            }
    //            else if (_startMousePosition.x < endPosition.x)
    //            {
    //                _direction--;
    //            }
    //            _direction = Mathf.Clamp(_direction, 0, _countChild);
    //        }

    //    rectTransform.DOAnchorPosX(_direction * _offsetBetweenChild * -1, 0.3f);
    //}
    #endregion
}
