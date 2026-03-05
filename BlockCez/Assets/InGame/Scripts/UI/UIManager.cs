using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Instance
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion

    [Header("Main Menu UI Elements")]
    [SerializeField] private GameObject mainMenuHolder; // tüm main menu UI tutucusu

    [Header("Game UI Elements")]
    [SerializeField] private GameObject gameMenuHolder; // tüm oyun UI tutucusu
    [SerializeField] private GameObject timerUI;        // mode göre açýlýp kapanýyor
    [SerializeField] private GameObject remainingMovesUI; // mode göre açýlýp kapanýyor
    [SerializeField] private TextMeshProUGUI remainingMovesText; // text referansý direkt inspector üzerinden
    [SerializeField] private TextMeshProUGUI timerUIText; // text referansý direkt inspector üzerinden

    [Header("Pop-up UI Elements")]
    [SerializeField] private GameObject losePopup;

    #region Event Handlers
    private void OnEnable()
    {
        GameEvents.OnGameStart += HandleGameStart;
        GameEvents.OnGameLose += ShowLosePopup;
        GameEvents.OnReturnToMenu += ShowMainMenu;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= HandleGameStart;
        GameEvents.OnGameLose -= ShowLosePopup;
        GameEvents.OnReturnToMenu -= ShowMainMenu;
    }
    #endregion

    #region Public Methods
    public void ConfigureUI(GameModeBase mode)
    {
        if (timerUI != null)
            timerUI.SetActive(mode.UseTimer());

        if (remainingMovesUI != null)
            remainingMovesUI.SetActive(mode.UseMoveLimit());
    }

    public void UpdateMoveText(int move)
    {
        if (remainingMovesText != null)
            remainingMovesText.text = "KALAN HAK: " + move.ToString();
    }
    public void UpdateTimeText(float time)
    {
        if (timerUIText != null)
            timerUIText.text = "KALAN ZAMAN: " + Mathf.RoundToInt(time).ToString("F2");
    }

    public void HandleGameStart()
    {
        if (mainMenuHolder != null)
            mainMenuHolder.SetActive(false);

        if (gameMenuHolder != null)
            gameMenuHolder.SetActive(true);
    }

    public void ShowLosePopup()
    {
        if (losePopup != null)
            losePopup.SetActive(true);
    }

    public void HideLosePopup()
    {
        if (losePopup != null)
            losePopup.SetActive(false);
    }

    public void ShowMainMenu()
    {
        if (mainMenuHolder != null)
            mainMenuHolder.SetActive(true);

        if (gameMenuHolder != null)
            gameMenuHolder.SetActive(false);

        HideLosePopup();
    }
    #endregion
}