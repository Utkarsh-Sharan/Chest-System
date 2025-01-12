using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    [SerializeField] private int maximumSlots;
    [SerializeField] private GameObject emptySlotObject;

    private void Start()
    {
        for (int i = 0; i < maximumSlots; ++i)
        {
            Instantiate(emptySlotObject, this.transform);
        }
    }
}
