using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStateMachine
{
    private IChestState currentState;
    private Dictionary<ChestStates, IChestState> states = new Dictionary<ChestStates, IChestState>();

    public ChestStateMachine()
    {
        CreateStates();
    }

    private void CreateStates()
    {
        states.Add(ChestStates.Locked, new LockedState());
        states.Add(ChestStates.Unlocking, new UnlockingState());
        states.Add(ChestStates.Unlocked, new UnlockedState());
    }

    public void OnClick(ChestItem chestItem)
    {
        currentState.OnClick(chestItem);
    }

    public void ChangeState(ChestStates newState) => ChangeState(states[newState]);

    private void ChangeState(IChestState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    public ChestStates GetCurrentState()
    {
        foreach (var statePair in states)
        {
            if (statePair.Value == currentState)
                return statePair.Key;
        }

        return ChestStates.Locked;
    }
}
