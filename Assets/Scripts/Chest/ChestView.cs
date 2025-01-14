using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Image chestImage;
    public void InitializeChestData(ChestScriptableObject chestSO)
    {
        chestImage.sprite = chestSO.ChestImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //display popup showing chest stats(coin and gem count).
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //close popup showing chest stats.

        //decided on the basis of STATE in which the chest is.
        //LOCKED    - popup to show Start Timer and Unlock with gems button.
        //UNLOCKING - popup to show Unlock with gems button only.
        //UNLOCKED  - change chest's state to COLLECTED.
        //COLLECTED - simply destroy THIS chest and change slot's state to EMPTY.
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //close popup showing chest stats.
    }
}