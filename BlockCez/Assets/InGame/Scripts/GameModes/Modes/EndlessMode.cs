using UnityEngine;

public class EndlessMode : GameModeBase
{
    public override bool UseScore()
    {
        return true;
    }


    public override bool CanMakeMove()
    {
        return true; 
    }
    public override void OnMove()
    {
        ScoreManager.Instance.AddScore(10);

    }

    public override void OnWin()
    {
        Debug.Log("Kazandin");
    }

    public override void Update()
    {
        Debug.Log("Update calisiyo");
    }
}
