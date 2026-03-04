using UnityEngine;

public class TestMode : GameModeBase
{

    public override bool CanMakeMove()
    {
        return true;
    }

    public override void Init(GridManager grid)
    {
        currentGrid = grid;
    }

    public override void OnMove()
    {
        Debug.Log("Hamle Yaptin");

    }

    public override void OnWin()
    {
        Debug.Log("Kazandin");
    }

    public override void Update()
    {
        Debug.Log("Update calisiyo");
    }

    public override int GetSize()
    {
        return 10;
    }
}
