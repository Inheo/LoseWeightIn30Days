using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingAnthropometricParameters : MonoBehaviour
{
    [SerializeField] private InputField _nameInputField;
    [SerializeField] private InputField _heightInputField;

    [Header("Before traning")]
    [SerializeField] private InputField _beforeWeightInputField;
    [SerializeField] private InputField _beforeChestInputField;
    [SerializeField] private InputField _beforeWaistInputField;
    [SerializeField] private InputField _beforeThighsInputField;

    [Header("After traning")]
    [SerializeField] private InputField _afterWeightInputField;
    [SerializeField] private InputField _afterChestInputField;
    [SerializeField] private InputField _afterWaistInputField;
    [SerializeField] private InputField _afterThighsInputField;


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        LongTermParameters longTermParameters = Menu.Instance.AllParameters;

        Debug.Log(longTermParameters.HumanHeight.Length);
        if(longTermParameters.HumanName.Length > 0)
            _nameInputField.text = longTermParameters.HumanName;
        if (longTermParameters.HumanHeight.Length > 0)
        {
            _heightInputField.contentType = InputField.ContentType.Standard;
            _heightInputField.text = "Ваш рост: " + longTermParameters.HumanHeight;
        }

        if (longTermParameters.AnthropometryAfterTraining.Weight.Length > 0)
        {
            _afterWeightInputField.contentType = InputField.ContentType.Standard;
            _afterWeightInputField.text = "Вес: " + longTermParameters.AnthropometryAfterTraining.Weight + " кг";
        }
        if (longTermParameters.AnthropometryAfterTraining.Chest.Length > 0)
        {
            _afterChestInputField.contentType = InputField.ContentType.Standard;
            _afterChestInputField.text = "Грудь: " + longTermParameters.AnthropometryAfterTraining.Chest + " см";
        }
        if (longTermParameters.AnthropometryAfterTraining.Waist.Length > 0)
        {
            _afterWaistInputField.contentType = InputField.ContentType.Standard;
            _afterWaistInputField.text = "Талия: " + longTermParameters.AnthropometryAfterTraining.Waist + " см";
        }
        if (longTermParameters.AnthropometryAfterTraining.Thighs.Length > 0)
        {
            _afterThighsInputField.contentType = InputField.ContentType.Standard;
            _afterThighsInputField.text = "Бёдра: " + longTermParameters.AnthropometryAfterTraining.Thighs + " см";
        }

        if (longTermParameters.AnthropometryBeforeTraining.Weight.Length > 0)
        {
            _beforeWeightInputField.contentType = InputField.ContentType.Standard;
            _beforeWeightInputField.text = "Вес: " + longTermParameters.AnthropometryBeforeTraining.Weight + " кг";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Chest.Length > 0)
        {
            _beforeChestInputField.contentType = InputField.ContentType.Standard;
            _beforeChestInputField.text = "Грудь: " + longTermParameters.AnthropometryBeforeTraining.Chest + " см";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Waist.Length > 0)
        {
            _beforeWaistInputField.contentType = InputField.ContentType.Standard;
            _beforeWaistInputField.text = "Талия: " + longTermParameters.AnthropometryBeforeTraining.Waist + " см";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Thighs.Length > 0)
        {
            _beforeThighsInputField.contentType = InputField.ContentType.Standard;
            _beforeThighsInputField.text = "Бёдра: " + longTermParameters.AnthropometryBeforeTraining.Thighs + " см";
        }
    }

    public void ChangeName(string name)
    {
        Menu.Instance.AllParameters.HumanName = name;
    }

    public void ChangeHeight(string height)
    {
        _heightInputField.contentType = InputField.ContentType.DecimalNumber;
        _heightInputField.text = height;

        height = height.Replace("Ваш рост: ", "");
        height = height.Replace(" см", "");

        Menu.Instance.AllParameters.HumanHeight = height;

    }
    public void AddHintForHeight()
    {
        _heightInputField.text = _heightInputField.text.Replace("Ваш рост: ", "");
        _heightInputField.text = _heightInputField.text.Replace(" см", "");

        if (_heightInputField.text.Length > 0)
        {
            _heightInputField.contentType = InputField.ContentType.Standard;
            _heightInputField.text = "Ваш рост: " + _heightInputField.text + " см";
        }
    }

    #region Changing before traning parametrs
    public void ChangeBeforeWeight(string text)
    {
        _beforeWeightInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeWeightInputField.text = text;

        text = text.Replace("Вес: ", "");
        text = text.Replace(" кг", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Weight = text;
    }
    public void AddHintForBeforeWeight()
    {
        _beforeWeightInputField.text = _beforeWeightInputField.text.Replace("Вес: ", "");
        _beforeWeightInputField.text = _beforeWeightInputField.text.Replace(" кг", "");

        if (_beforeWeightInputField.text.Length > 0)
        {
            _beforeWeightInputField.contentType = InputField.ContentType.Standard;
            _beforeWeightInputField.text = "Вес: " + _beforeWeightInputField.text + " кг";
        }
    }

    public void ChangeBeforeChest(string text)
    {
        _beforeChestInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeChestInputField.text = text;

        text = text.Replace("Грудь: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Chest = text;
    }
    public void AddHintForBeforeChest()
    {
        _beforeChestInputField.text = _beforeChestInputField.text.Replace("Грудь: ", "");
        _beforeChestInputField.text = _beforeChestInputField.text.Replace(" см", "");

        if (_beforeChestInputField.text.Length > 0)
        {
            _beforeChestInputField.contentType = InputField.ContentType.Standard;
            _beforeChestInputField.text = "Грудь: " + _beforeChestInputField.text + " см";
        }
    }

    public void ChangeBeforeWaist(string text)
    {
        _beforeWaistInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeWaistInputField.text = text;

        text = text.Replace("Талия: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Waist = text;
    }
    public void AddHintForBeforeWaist()
    {
        _beforeWaistInputField.text = _beforeWaistInputField.text.Replace("Талия: ", "");
        _beforeWaistInputField.text = _beforeWaistInputField.text.Replace(" см", "");

        if (_beforeWaistInputField.text.Length > 0)
        {
            _beforeWaistInputField.contentType = InputField.ContentType.Standard;
            _beforeWaistInputField.text = "Талия: " + _beforeWaistInputField.text + " см";
        }
    }

    public void ChangeBeforeThighs(string text)
    {
        _beforeThighsInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeThighsInputField.text = text;

        text = text.Replace("Бёдра: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Thighs = text;
    }
    public void AddHintForBeforeThighs()
    {
        _beforeThighsInputField.text = _beforeThighsInputField.text.Replace("Бёдра: ", "");
        _beforeThighsInputField.text = _beforeThighsInputField.text.Replace(" см", "");

        if (_beforeThighsInputField.text.Length > 0)
        {
            _beforeThighsInputField.contentType = InputField.ContentType.Standard;
            _beforeThighsInputField.text = "Бёдра: " + _beforeThighsInputField.text + " см";
        }
    }
    #endregion

    #region Changing after traning parametrs
    public void ChangeAfterWeight(string text)
    {
        _afterWeightInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterWeightInputField.text = text;

        text = text.Replace("Вес: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Weight = text;
    }
    public void AddHintForAfterWeight()
    {
        _afterWeightInputField.text = _afterWeightInputField.text.Replace("Вес: ", "");
        _afterWeightInputField.text = _afterWeightInputField.text.Replace(" кг", "");

        if (_afterWeightInputField.text.Length > 0)
        {
            _afterWeightInputField.contentType = InputField.ContentType.Standard;
            _afterWeightInputField.text = "Вес: " + _afterWeightInputField.text + " кг";
        }
    }

    public void ChangeAfterChest(string text)
    {
        _afterChestInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterChestInputField.text = text;

        text = text.Replace("Грудь: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Chest = text;
    }
    public void AddHintForAfterChest()
    {
        _afterChestInputField.text = _afterChestInputField.text.Replace("Грудь: ", "");
        _afterChestInputField.text = _afterChestInputField.text.Replace(" см", "");

        if (_afterChestInputField.text.Length > 0)
        {
            _afterChestInputField.contentType = InputField.ContentType.Standard;
            _afterChestInputField.text = "Грудь: " + _afterChestInputField.text + " см";
        }
    }

    public void ChangeAfterWaist(string text)
    {
        _afterWaistInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterWaistInputField.text = text;

        text = text.Replace("Талия: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Waist = text;
    }
    public void AddHintForAfterWaist()
    {
        _afterWaistInputField.text = _afterWaistInputField.text.Replace("Талия: ", "");
        _afterWaistInputField.text = _afterWaistInputField.text.Replace(" см", "");

        if (_afterWaistInputField.text.Length > 0)
        {
            _afterWaistInputField.contentType = InputField.ContentType.Standard;
            _afterWaistInputField.text = "Талия: " + _afterWaistInputField.text + " см";
        }
    }

    public void ChangeAfterThighs(string text)
    {
        _afterThighsInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterThighsInputField.text = text;

        text = text.Replace("Бёдра: ", "");
        text = text.Replace(" см", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Thighs = text;
    }
    public void AddHintForAfterThighs()
    {
        _afterThighsInputField.text = _afterThighsInputField.text.Replace("Бёдра: ", "");
        _afterThighsInputField.text = _afterThighsInputField.text.Replace(" см", "");

        if (_afterThighsInputField.text.Length > 0)
        {

            _afterThighsInputField.contentType = InputField.ContentType.Standard;
            _afterThighsInputField.text = "Бёдра: " + _afterThighsInputField.text + " см";
        }
    }
    #endregion
}
