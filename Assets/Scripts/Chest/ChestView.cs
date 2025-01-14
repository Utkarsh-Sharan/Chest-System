using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Image chestImage;
    private ChestType chestType;
    private RangeInt coinRange;
    private RangeInt gemRange;
    private int unlockTime;

    private ChestController chestController;

    public void SetController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void InitializeChestData(ChestScriptableObject chestSO)
    {
        this.chestImage.sprite = chestSO.ChestImage;
        this.chestType = chestSO.ChestType;
        this.coinRange = chestSO.CoinRange;
        this.gemRange = chestSO.GemRange;
        this.unlockTime = chestSO.UnlockTime;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        chestController.OnMouseHover();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chestController.OnMouseClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        chestController.OnMouseLeave();
    }
}