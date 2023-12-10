using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action<PlayerStateBase> OnPlayerStateChanged;
    public static event Action OnScoreIncreased;
    public static void TriggerPlayerStateChanged(PlayerStateBase newState)
    {
        OnPlayerStateChanged?.Invoke(newState);
    }
    public static void TriggerScoreIncreased()
    {
        OnScoreIncreased?.Invoke();
    }

}
