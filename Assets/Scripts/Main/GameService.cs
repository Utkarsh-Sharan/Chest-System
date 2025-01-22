using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public SlotService SlotService { get; private set; }
    public ChestService ChestService { get; private set; }
    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;

    [Header("Chest properties")]
    [SerializeField] private List<ChestScriptableObject> chestSO;
    [SerializeField] private ChestController chestController;

    [Header("Slot properties")]
    [SerializeField] private SlotController slotController;

    protected override void Awake()
    {
        base.Awake();

        SlotService = new SlotService(slotController);
        ChestService = new ChestService(chestSO, chestController);

    }
}