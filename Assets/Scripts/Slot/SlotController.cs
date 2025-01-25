using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int maximumSlots;
    [SerializeField] private GameObject emptySlotPrefab;
    private List<SlotItem> slots = new List<SlotItem>();

    private int currentIndex;

    private void Start()
    {
        for (int i = 0; i < maximumSlots; ++i)
        {
            GameObject slotObject = Instantiate(emptySlotPrefab, this.transform);
            SlotItem slotItem = slotObject.GetComponent<SlotItem>();
            slots.Add(slotItem);
        }
    }

    public bool IsEmptySlotAvailable()
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            if (slots[i].GetSlotState() == SlotState.Empty)
            {
                currentIndex = i;
                return true;
            }
        }

        GameService.Instance.UIService.ShowMessage("No slots available, try later!");
        return false;
    }

    public int AddChestToSlot(ChestView chestObject)
    {
        chestObject.transform.SetParent(GetSlotTransform(currentIndex));
        chestObject.transform.localPosition = Vector3.zero;

        UpdateSlotState(currentIndex, SlotState.Occupied);
        return currentIndex;
    }

    public void RemoveChestFromSlot(int index)
    {
        UpdateSlotState(index, SlotState.Empty);
    }

    private Transform GetSlotTransform(int index) => slots[index].transform;

    private void UpdateSlotState(int index, SlotState state) => slots[index].SetSlotState(state);
}
