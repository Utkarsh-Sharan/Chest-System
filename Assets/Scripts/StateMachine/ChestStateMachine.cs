using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStateMachine
{
    private IChestState currentState;
    private Dictionary<ChestStates, IChestState> states = new Dictionary<ChestStates, IChestState>();

    public ChestStateMachine(ChestView chestObject)
    {
        CreateStates(chestObject);
    }

    public void OnClick(ChestView chestObject)
    {
        currentState.OnClick(chestObject);
    }

    public void ChangeState(ChestStates newState) => ChangeState(states[newState]);

    private void ChangeState(IChestState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    private void CreateStates(ChestView chestObject)
    {
        states.Add(ChestStates.Locked, new LockedState(chestObject));
        states.Add(ChestStates.Unlocking, new UnlockingState(chestObject));
        states.Add(ChestStates.Unlocked, new UnlockedState(chestObject));
        states.Add(ChestStates.Collected, new CollectedState(chestObject));
    }
}
