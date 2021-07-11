using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class MakingAnInAppPurchase : MonoBehaviour
{
    public event Action OnPurchaseComplete;

    public static MakingAnInAppPurchase Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PurchaseComplete(Product product)
    {
        if (product.definition.id == "premium")
        {
            Menu.Instance.AllParameters.IsPremiumOpen = true;
            OnPurchaseComplete?.Invoke();
            Menu.Instance.AllParameters.SaveToFile();
        }
    }
}
