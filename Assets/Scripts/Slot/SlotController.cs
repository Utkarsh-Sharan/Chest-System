using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int maximumSlots;
    [SerializeField] private GameObject emptySlotObject;
    private List<SlotItem> slots = new List<SlotItem>();

    private void Start()
    {
        for (int i = 0; i < maximumSlots; ++i)
        {
            GameObject slotObject = Instantiate(emptySlotObject, this.transform);
            SlotItem slotItem = slotObject.GetComponent<SlotItem>();
            slots.Add(slotItem);
        }
    }

    public int GetFirstAvailableEmptySlot()
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            if (slots[i].GetSlotState() == SlotState.Empty)
                return i;
        }

        return -1;
    }

    public Transform GetSlotTransform(int index) => slots[index].transform;

    public void UpdateSlotState(int index, SlotState state) => slots[index].SetSlotState(state);
}
