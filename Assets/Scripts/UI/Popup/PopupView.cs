using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupView : MonoBehaviour 
{
    protected const int minutesPerGem = 10;

    public abstract void Setup(ChestScriptableObject chestData, ChestItem chestItem);

    protected void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }
}
