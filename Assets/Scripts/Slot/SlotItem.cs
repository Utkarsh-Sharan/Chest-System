using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
    private SlotState slotState;

    private void Start()
    {
        this.slotState = SlotState.Empty;
    }

    public void SetSlotState(SlotState slotState)
    {
        this.slotState = slotState;
    }

    public SlotState GetSlotState()
    {
        return this.slotState;
    }
}
