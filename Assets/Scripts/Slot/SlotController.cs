using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int maximumSlots;
    [SerializeField] private GameObject emptySlotObject;
    private List<SlotItem> slots = new List<SlotItem>();

    private int currentIndex;

    private void Start()
    {
        for (int i = 0; i < maximumSlots; ++i)
        {
            GameObject slotObject = Instantiate(emptySlotObject, this.transform);
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
        //debug(and other ops) over here if not present.
        Debug.Log("No available slots to create a chest.");
        return false;
    }

    public void AddChestToSlot(ChestView chestObject)
    {
        chestObject.transform.SetParent(GetSlotTransform(currentIndex));
        chestObject.transform.localPosition = Vector3.zero;

        UpdateSlotState(currentIndex, SlotState.Occupied);
    }

    private Transform GetSlotTransform(int index) => slots[index].transform;

    private void UpdateSlotState(int index, SlotState state) => slots[index].SetSlotState(state);
}
