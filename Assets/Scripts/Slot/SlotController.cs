using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    private SlotState slotState;
    [SerializeField] private int maximumSlots;
    [SerializeField] private GameObject emptySlotObject;

    private void Start()
    {
        slotState = SlotState.Empty;

        for (int i = 0; i < maximumSlots; ++i)
        {
            Instantiate(emptySlotObject, this.transform);
        }
    }
}
