using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView chestView;
    private List<ChestScriptableObject> chestSO;

    public void CreateRandomChest(List<ChestScriptableObject> chestSO)
    {
        this.chestSO = chestSO;

        int firstEmptySlotIndex = GameService.Instance.SlotService.GetFirstAvailableEmptySlot();
        if (firstEmptySlotIndex == -1)
        {
            Debug.Log("No available slots to create a chest.");
            return;
        }

        ChestScriptableObject randomChestSO = chestSO[Random.Range(0, chestSO.Count)];

        Transform slotTransform = GameService.Instance.SlotService.GetSlotTransform(firstEmptySlotIndex);

        GameObject chestObject = Instantiate(chestView.gameObject, slotTransform.position, Quaternion.identity, slotTransform);

        GameService.Instance.SlotService.UpdateSlotState(firstEmptySlotIndex, SlotState.Occupied);
    }
}
