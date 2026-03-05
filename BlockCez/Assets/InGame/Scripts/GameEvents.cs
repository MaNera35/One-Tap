using System;
public static class GameEvents
{ 
    public static event Action OnGameStart;
    public static event Action OnGameLose;
    public static event Action OnReturnToMenu;

    public static void StartGame() => OnGameStart?.Invoke();
    public static void LoseGame() => OnGameLose?.Invoke();
    public static void ReturnMenu() => OnReturnToMenu?.Invoke();
}