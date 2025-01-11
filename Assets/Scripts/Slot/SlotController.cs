using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    private SlotState slotState;
    [SerializeField] private GameObject emptySlotImage;

    public void SetSlotState(SlotState slotState)
    {
        this.slotState = slotState;

        switch(this.slotState)
        {
            case SlotState.Empty:
                emptySlotImage.SetActive(true);
                break;

            case SlotState.Occupied:
                emptySlotImage.SetActive(false);
                break;
        }
    }

    public SlotState GetSlotState()
    {
        return slotState;
    }
}
