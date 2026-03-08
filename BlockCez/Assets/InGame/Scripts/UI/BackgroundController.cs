using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Sprite menuBackgroundImage;
    [SerializeField] private Sprite gameBackgroundImage;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    private void SwitchBackground(Sprite bg)
    {
        image.sprite = bg;
    }

    private void SwitchToMenu()
    {
        Debug.Log("Menu Background");
        SwitchBackground(menuBackgroundImage);
    }
    private void SwitchToGame()
    {
        Debug.Log("Game Background");
        SwitchBackground(gameBackgroundImage);
    }

    private void OnEnable()
    {
        GameEvents.OnGameStart += SwitchToGame;
        GameEvents.OnReturnToMenu += SwitchToMenu;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= SwitchToGame;
        GameEvents.OnReturnToMenu -= SwitchToMenu;
    }
}
