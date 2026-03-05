using UnityEngine;

[CreateAssetMenu(fileName = "GameModeSettings", menuName = "Settings/GameModeSettings")]
public class GameModeSettings : ScriptableObject
{
    [Header("Grid Settings")]
    public int gridSize = 5;

    [Header("Move Limit Mode")]
    public int maxMoves = 10;

    [Header("Time Attack Mode")]
    public float timeLimit = 60f;

    [Header("Other")]
    public int scrambleMoves = 5;
}