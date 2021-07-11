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
            _heightInputField.text = "��� ����: " + longTermParameters.HumanHeight;
        }

        if (longTermParameters.AnthropometryAfterTraining.Weight.Length > 0)
        {
            _afterWeightInputField.contentType = InputField.ContentType.Standard;
            _afterWeightInputField.text = "���: " + longTermParameters.AnthropometryAfterTraining.Weight + " ��";
        }
        if (longTermParameters.AnthropometryAfterTraining.Chest.Length > 0)
        {
            _afterChestInputField.contentType = InputField.ContentType.Standard;
            _afterChestInputField.text = "�����: " + longTermParameters.AnthropometryAfterTraining.Chest + " ��";
        }
        if (longTermParameters.AnthropometryAfterTraining.Waist.Length > 0)
        {
            _afterWaistInputField.contentType = InputField.ContentType.Standard;
            _afterWaistInputField.text = "�����: " + longTermParameters.AnthropometryAfterTraining.Waist + " ��";
        }
        if (longTermParameters.AnthropometryAfterTraining.Thighs.Length > 0)
        {
            _afterThighsInputField.contentType = InputField.ContentType.Standard;
            _afterThighsInputField.text = "�����: " + longTermParameters.AnthropometryAfterTraining.Thighs + " ��";
        }

        if (longTermParameters.AnthropometryBeforeTraining.Weight.Length > 0)
        {
            _beforeWeightInputField.contentType = InputField.ContentType.Standard;
            _beforeWeightInputField.text = "���: " + longTermParameters.AnthropometryBeforeTraining.Weight + " ��";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Chest.Length > 0)
        {
            _beforeChestInputField.contentType = InputField.ContentType.Standard;
            _beforeChestInputField.text = "�����: " + longTermParameters.AnthropometryBeforeTraining.Chest + " ��";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Waist.Length > 0)
        {
            _beforeWaistInputField.contentType = InputField.ContentType.Standard;
            _beforeWaistInputField.text = "�����: " + longTermParameters.AnthropometryBeforeTraining.Waist + " ��";
        }
        if (longTermParameters.AnthropometryBeforeTraining.Thighs.Length > 0)
        {
            _beforeThighsInputField.contentType = InputField.ContentType.Standard;
            _beforeThighsInputField.text = "�����: " + longTermParameters.AnthropometryBeforeTraining.Thighs + " ��";
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

        height = height.Replace("��� ����: ", "");
        height = height.Replace(" ��", "");

        Menu.Instance.AllParameters.HumanHeight = height;

    }
    public void AddHintForHeight()
    {
        _heightInputField.text = _heightInputField.text.Replace("��� ����: ", "");
        _heightInputField.text = _heightInputField.text.Replace(" ��", "");

        if (_heightInputField.text.Length > 0)
        {
            _heightInputField.contentType = InputField.ContentType.Standard;
            _heightInputField.text = "��� ����: " + _heightInputField.text + " ��";
        }
    }

    #region Changing before traning parametrs
    public void ChangeBeforeWeight(string text)
    {
        _beforeWeightInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeWeightInputField.text = text;

        text = text.Replace("���: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Weight = text;
    }
    public void AddHintForBeforeWeight()
    {
        _beforeWeightInputField.text = _beforeWeightInputField.text.Replace("���: ", "");
        _beforeWeightInputField.text = _beforeWeightInputField.text.Replace(" ��", "");

        if (_beforeWeightInputField.text.Length > 0)
        {
            _beforeWeightInputField.contentType = InputField.ContentType.Standard;
            _beforeWeightInputField.text = "���: " + _beforeWeightInputField.text + " ��";
        }
    }

    public void ChangeBeforeChest(string text)
    {
        _beforeChestInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeChestInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Chest = text;
    }
    public void AddHintForBeforeChest()
    {
        _beforeChestInputField.text = _beforeChestInputField.text.Replace("�����: ", "");
        _beforeChestInputField.text = _beforeChestInputField.text.Replace(" ��", "");

        if (_beforeChestInputField.text.Length > 0)
        {
            _beforeChestInputField.contentType = InputField.ContentType.Standard;
            _beforeChestInputField.text = "�����: " + _beforeChestInputField.text + " ��";
        }
    }

    public void ChangeBeforeWaist(string text)
    {
        _beforeWaistInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeWaistInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Waist = text;
    }
    public void AddHintForBeforeWaist()
    {
        _beforeWaistInputField.text = _beforeWaistInputField.text.Replace("�����: ", "");
        _beforeWaistInputField.text = _beforeWaistInputField.text.Replace(" ��", "");

        if (_beforeWaistInputField.text.Length > 0)
        {
            _beforeWaistInputField.contentType = InputField.ContentType.Standard;
            _beforeWaistInputField.text = "�����: " + _beforeWaistInputField.text + " ��";
        }
    }

    public void ChangeBeforeThighs(string text)
    {
        _beforeThighsInputField.contentType = InputField.ContentType.DecimalNumber;
        _beforeThighsInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryBeforeTraining.Thighs = text;
    }
    public void AddHintForBeforeThighs()
    {
        _beforeThighsInputField.text = _beforeThighsInputField.text.Replace("�����: ", "");
        _beforeThighsInputField.text = _beforeThighsInputField.text.Replace(" ��", "");

        if (_beforeThighsInputField.text.Length > 0)
        {
            _beforeThighsInputField.contentType = InputField.ContentType.Standard;
            _beforeThighsInputField.text = "�����: " + _beforeThighsInputField.text + " ��";
        }
    }
    #endregion

    #region Changing after traning parametrs
    public void ChangeAfterWeight(string text)
    {
        _afterWeightInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterWeightInputField.text = text;

        text = text.Replace("���: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Weight = text;
    }
    public void AddHintForAfterWeight()
    {
        _afterWeightInputField.text = _afterWeightInputField.text.Replace("���: ", "");
        _afterWeightInputField.text = _afterWeightInputField.text.Replace(" ��", "");

        if (_afterWeightInputField.text.Length > 0)
        {
            _afterWeightInputField.contentType = InputField.ContentType.Standard;
            _afterWeightInputField.text = "���: " + _afterWeightInputField.text + " ��";
        }
    }

    public void ChangeAfterChest(string text)
    {
        _afterChestInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterChestInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Chest = text;
    }
    public void AddHintForAfterChest()
    {
        _afterChestInputField.text = _afterChestInputField.text.Replace("�����: ", "");
        _afterChestInputField.text = _afterChestInputField.text.Replace(" ��", "");

        if (_afterChestInputField.text.Length > 0)
        {
            _afterChestInputField.contentType = InputField.ContentType.Standard;
            _afterChestInputField.text = "�����: " + _afterChestInputField.text + " ��";
        }
    }

    public void ChangeAfterWaist(string text)
    {
        _afterWaistInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterWaistInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Waist = text;
    }
    public void AddHintForAfterWaist()
    {
        _afterWaistInputField.text = _afterWaistInputField.text.Replace("�����: ", "");
        _afterWaistInputField.text = _afterWaistInputField.text.Replace(" ��", "");

        if (_afterWaistInputField.text.Length > 0)
        {
            _afterWaistInputField.contentType = InputField.ContentType.Standard;
            _afterWaistInputField.text = "�����: " + _afterWaistInputField.text + " ��";
        }
    }

    public void ChangeAfterThighs(string text)
    {
        _afterThighsInputField.contentType = InputField.ContentType.DecimalNumber;
        _afterThighsInputField.text = text;

        text = text.Replace("�����: ", "");
        text = text.Replace(" ��", "");

        Menu.Instance.AllParameters.AnthropometryAfterTraining.Thighs = text;
    }
    public void AddHintForAfterThighs()
    {
        _afterThighsInputField.text = _afterThighsInputField.text.Replace("�����: ", "");
        _afterThighsInputField.text = _afterThighsInputField.text.Replace(" ��", "");

        if (_afterThighsInputField.text.Length > 0)
        {

            _afterThighsInputField.contentType = InputField.ContentType.Standard;
            _afterThighsInputField.text = "�����: " + _afterThighsInputField.text + " ��";
        }
    }
    #endregion
}
