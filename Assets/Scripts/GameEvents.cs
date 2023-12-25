using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action<PlayerStateBase> OnPlayerStateChanged;
    public static event Action OnScoreIncreased;
    public static event Action<bool> OnGamePausedStateChanged;
    public static event Action OnGround;
    public static void TriggerPlayerStateChanged(PlayerStateBase newState)
    {
        OnPlayerStateChanged?.Invoke(newState);
    }
    public static void TriggerScoreIncreased()
    {
        OnScoreIncreased?.Invoke();
    }
    public static void TriggerGamePausedStateChanged(bool isGamePaused)
    {
        OnGamePausedStateChanged?.Invoke(isGamePaused);
    }
    public static void OnGroundEvents()
    {
        OnGround?.Invoke();
    }
}
