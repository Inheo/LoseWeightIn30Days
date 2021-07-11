using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _hintsThatOptionIsNotAvailable;
    [SerializeField] private Text[] _premiumOptionsTexts;
    [SerializeField] private Image[] _premiumOptionsImages;
    [SerializeField] private Button[] _premiumOptionsButtons;

    [SerializeField] private Color _colorForAvailableOptions;
    [SerializeField] private Color _colorForUnavailableOptions;

    void Start()
    {
        MakingAnInAppPurchase.Instance.OnPurchaseComplete += ActivePremiumOptions;

        if (Menu.Instance.AllParameters.IsPremiumOpen)
        {
            ActivePremiumOptions();
        }
    }

    private void ActivePremiumOptions()
    {
        for (int i = 0; i < _hintsThatOptionIsNotAvailable.Length; i++)
        {
            _hintsThatOptionIsNotAvailable[i].SetActive(false);
            _premiumOptionsTexts[i].color = _colorForAvailableOptions;
            _premiumOptionsImages[i].color = _colorForAvailableOptions;
            _premiumOptionsButtons[i].interactable = true;
        }
    }
}
