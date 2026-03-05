using UnityEngine;

public class EndlessMode : GameModeBase
{

    public override bool CanMakeMove()
    {
        return true; 
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
}
