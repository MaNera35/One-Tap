using UnityEngine;

public abstract class GameModeBase
{
    protected GridManager currentGrid;
    protected int gridSize = 5;

    // Baþlangýçta grid ve level parametreleri gönderilir
    public virtual void Init(GridManager grid)
    {
        currentGrid = grid;
    }

  
    public abstract bool CanMakeMove();
    public abstract void OnMove();
    public abstract void OnWin();
    public abstract void Update();

    public virtual int GetSize() => gridSize;
}