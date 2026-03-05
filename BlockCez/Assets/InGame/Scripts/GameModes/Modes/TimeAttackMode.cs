using UnityEngine;

public class TimeAttackMode : GameModeBase
{
    private float remainingTime;

    public override void OnLevelStart()
    {
        remainingTime = settings.timeLimit;
    }

    public override bool CanMakeMove()
    {
        return remainingTime > 0;
    }

    public override void OnMove()
    {
        
    }

    public override void OnWin()
    {
        
    }

    public override void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            Debug.Log("Lose");
            GameEvents.LoseGame();
        }
        remainingTime = Mathf.Clamp(remainingTime, 0, settings.timeLimit);

        UIManager.Instance.UpdateTimeText(remainingTime);
    }

    public override bool UseTimer()
    {
        return true;
    }
}
