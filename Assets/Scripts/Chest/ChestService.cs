using System.Collections.Generic;

public class ChestService
{
    private ChestController chestController;
    private List<ChestScriptableObject> chestSO;

    public ChestService(List<ChestScriptableObject> chestSO, ChestController chestController)
    {
        this.chestController = chestController;
        this.chestSO = chestSO;

        chestController.Init();
    }

    public void CreateRandomChest()
    {
        chestController.CreateRandomChest(chestSO);
    }
}
