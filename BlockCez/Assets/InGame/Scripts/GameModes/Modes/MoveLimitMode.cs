using UnityEngine;

public class MoveLimitMode : GameModeBase
{
    public int remainingMoves = 10;

    public override bool CanMakeMove()
    {
        return remainingMoves > 0;
    }

    public override void OnLevelStart()
    {
        base.OnLevelStart();

        UIManager.Instance.UpdateMoveText(remainingMoves);
    }

    public override void OnMove()
    {
        remainingMoves--;

        if (remainingMoves <= 0)
        {
            GameEvents.LoseGame();
        }
        UIManager.Instance.UpdateMoveText(remainingMoves);
    }

    public override void OnWin()
    {
        remainingMoves += 5;
        UIManager.Instance.UpdateMoveText(remainingMoves);
        ScoreManager.Instance.AddScore(10);

        currentGrid.GenerateNewLevel(settings.gridSize,settings);
    }

    public override void Update()
    {

    }

    public override bool UseMoveLimit()
    {
        return true;
    }

    public override bool UseScore()
    {
        return true;
    }
}
