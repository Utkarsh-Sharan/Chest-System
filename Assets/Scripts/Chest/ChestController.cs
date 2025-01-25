using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView chestView;
    private ChestView unlockingChest;

    public void CreateRandomChest(List<ChestScriptableObject> chestSO)
    {
        bool isEmptySlotAvailable = GameService.Instance.SlotService.IsEmptySlotAvailable();
        if (!isEmptySlotAvailable)
            return;

        ChestScriptableObject randomChestSO = chestSO[Random.Range(0, chestSO.Count)];
        ChestView chestObject = Instantiate(chestView);
        chestObject.InitializeChestData(this, randomChestSO);

        int chestID = GameService.Instance.SlotService.AddChestToSlot(chestObject);
        chestObject.SetChestID(chestID);
    }

    public bool IsAnotherChestUnlocking() => unlockingChest != null;

    public void SetUnlockingChest(ChestView chestView) => unlockingChest = chestView;

    public void ClearUnlockingChest() => unlockingChest = null;
}