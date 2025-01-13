using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public SlotService SlotService { get; private set; }
    public ChestService ChestService { get; private set; }
    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;

    [SerializeField] private List<ChestScriptableObject> chestSO;
    [SerializeField] private ChestController chestController;

    protected override void Awake()
    {
        base.Awake();

        SlotService = new SlotService();
        ChestService = new ChestService(chestSO, chestController);

    }
}