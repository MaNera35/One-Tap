using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    [SerializeField] private UIManager uiManager;

    [SerializeField] private GameModeSettings endlessSettings;
    [SerializeField] private GameModeSettings moveLimitSettings;
    [SerializeField] private GameModeSettings timeAttackSettings;


    public void StartTimeAttackGame()
    {
        StartMode(new TimeAttackMode(), timeAttackSettings);
    }
    public void StartEndlessGame()
    {
        StartMode(new EndlessMode(), endlessSettings);
    }

    public void StartMoveLimitGame()
    {
        StartMode(new MoveLimitMode(), moveLimitSettings);
    }

    private void StartMode(GameModeBase mode, GameModeSettings settings)
    {
        mode.Init(gridManager, settings);
        uiManager.ConfigureUI(mode);
        GameEvents.StartGame();

        gridManager.SetMode(mode, settings);
    }

    public void StartReplayGame()
    {
        GameModeBase modbase = gridManager.currentMode;
        GameModeSettings modbaseSettings = modbase.GetMode();
        StartMode(modbase, modbaseSettings);
    }
}