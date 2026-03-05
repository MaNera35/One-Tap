using UnityEngine;

public abstract class GameModeBase
{
    protected GridManager currentGrid;
    protected GameModeSettings settings; // Inspector’dan gelen ayarlar

    // Baþlangýçta grid ve mode parametreleri gönderilir
    public virtual void Init(GridManager grid, GameModeSettings modeSettings)
    {
        currentGrid = grid;
        settings = modeSettings;
    }

    public virtual void OnLevelStart()
    {
        ScoreManager.Instance.ResetScore();
    }

    // Hangi UI aktif olacak (timer / move limit)
    public virtual bool UseTimer() => false;
    public virtual bool UseMoveLimit() => false;
    public virtual bool UseScore() => false;

    // Mode’un grid boyutu artýk settings’ten okunacak
    public virtual int GetSize() => settings != null ? settings.gridSize : 5;

    // Her modun implement etmesi gereken metodlar
    public abstract bool CanMakeMove();
    public abstract void OnMove();
    public abstract void OnWin();
    public abstract void Update();
}