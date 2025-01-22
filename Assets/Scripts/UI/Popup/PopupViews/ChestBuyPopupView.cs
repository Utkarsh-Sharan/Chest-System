using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBuyPopupView : PopupView
{
    [SerializeField] private Button closeButton;

    public override void Setup(ChestView chestView)
    {
        closeButton.onClick.AddListener(ClosePopup);
    }
}
