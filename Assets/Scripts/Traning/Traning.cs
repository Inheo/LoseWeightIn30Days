using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class Traning : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buyAccessPanel;

    [SerializeField] private GameObject[] _freeBgs;
    [SerializeField] private GameObject[] _premiumBgs;

    [SerializeField] private Text[] levelTexts;
    [SerializeField] private string[] levelNames;

    [SerializeField] private Text[] currentDayTexts;

    private void Start()
    {
        MakingAnInAppPurchase.Instance.OnPurchaseComplete += BuyPremium;
        ChangeLevelTextName();
        SetCurrentDayForTexts();
        ShowPremiumOrFreeBg();
    }

    public void ChangeLevelTextName()
    {
        for (int i = 0; i < Menu.Instance.AllParameters.LevelCurrentTranings.Length; i++)
        {
            levelTexts[i].text = levelNames[Menu.Instance.AllParameters.LevelCurrentTranings[i]];
        }
    }

    public void SetCurrentDayForTexts()
    {
        for (int i = 0; i < currentDayTexts.Length; i++)
        {
            int current = Menu.Instance.AllParameters.CurrentDayTranings[i];
            currentDayTexts[i].text = current > 0 ? current.ToString() : "-";
        }
    }

    private void ShowPremiumOrFreeBg()
    {
        if (Menu.Instance.AllParameters.IsPremiumOpen)
        {
            for (int i = 0; i < _premiumBgs.Length; i++)
            {
                _premiumBgs[i].SetActive(true);
                _freeBgs[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < _freeBgs.Length; i++)
            {
                _freeBgs[i].SetActive(true);
                _premiumBgs[i].SetActive(false);
            }
        }
    }

    #region BuyAccessPanel
    public void ShowBuyAccessPanel()
    {
        _buyAccessPanel.DOFade(1, 0.3f).OnComplete(() => _buyAccessPanel.blocksRaycasts = true);
    }
    public void HideBuyAccessPanel()
    {
        _buyAccessPanel.DOFade(0, 0.3f).OnStart(() => _buyAccessPanel.blocksRaycasts = false);
    }

    private void BuyPremium()
    {
        ShowPremiumOrFreeBg();
        HideBuyAccessPanel();
    }
    #endregion
}
