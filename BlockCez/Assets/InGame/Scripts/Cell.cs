using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int x;
    public int y;

    private GridManager gridManager;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init(int _x, int _y, GridManager manager)
    {
        x = _x;
        y = _y;
        gridManager = manager;
    }

    public void OnClick()
    {
        gridManager.OnCellPressed(x, y);
    }

    public void SetState(int value)
    {
        image.color = value == 0 ? Hex("#24345a") : Hex("#aeb8e6");
    }


    public static Color Hex(string hex)
    {
        ColorUtility.TryParseHtmlString(hex, out var color);
        return color;
    }
}
