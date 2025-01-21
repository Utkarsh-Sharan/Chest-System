using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupView : MonoBehaviour 
{
    public abstract void Setup(ChestView chestView);

    protected void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }
}
