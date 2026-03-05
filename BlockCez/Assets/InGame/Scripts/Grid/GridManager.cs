using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform gridParent;

    private GridLayoutGroup gridLayout;
    private int[,] grid;
    private Cell[,] cells;

    private GameModeBase currentMode;
    private int size;


    private void OnEnable()
    {
        //GameEvents.OnReturnToMenu += ResetGame;
    }
    private void OnDisable()
    {
        //GameEvents.OnReturnToMenu -= ResetGame;
    }

    #region Unity
    private void Awake()
    {
        gridLayout = gridParent.GetComponent<GridLayoutGroup>();
    }

    private void Update()
    {
        if (!gridParent.gameObject.activeInHierarchy) return;
        currentMode?.Update();
    }
    #endregion

    #region Grid Setup
    public void SetMode(GameModeBase mode, GameModeSettings settings)
    {
        ResetGame();

        currentMode = mode;
        currentMode.Init(this, settings);
        size = currentMode.GetSize();

        UIManager.Instance.ConfigureUI(currentMode);
        GenerateNewLevel(size, settings);
        currentMode.OnLevelStart();
    }

    public void GenerateNewLevel(int newSize, GameModeSettings settings)
    {
        size = newSize;
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = size;

        InitGrid();
        GenerateSolvedGrid();
        ScrambleGrid(settings.scrambleMoves);
        UpdateVisuals();
    }

    private void InitGrid()
    {
        grid = new int[size, size];
        cells = new Cell[size, size];

        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                GameObject obj = Instantiate(cellPrefab, gridParent);
                Cell cell = obj.GetComponent<Cell>();
                if (cell == null) Debug.LogError("Cell prefab missing Cell component!");
                cell.Init(x, y, this);
                cells[x, y] = cell;
            }
        }
    }

    private void GenerateSolvedGrid()
    {
        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
                grid[x, y] = 0;
    }

    private void ScrambleGrid(int moveCount)
    {
        for (int i = 0; i < moveCount; i++)
        {
            int x = Random.Range(0, size);
            int y = Random.Range(0, size);
            ApplyToggleLogic(x, y);
        }
    }
    #endregion

    #region Cell Interaction
    public void OnCellPressed(int x, int y)
    {
        if (!currentMode.CanMakeMove()) return;

        ApplyToggleLogic(x, y);
        currentMode.OnMove();

        UpdateVisuals();

        if (CheckWin())
            currentMode.OnWin();
    }

    private void ApplyToggleLogic(int x, int y)
    {
        Change(x, y);
        Change(x + 1, y);
        Change(x - 1, y);
        Change(x, y + 1);
        Change(x, y - 1);
    }

    private void Change(int x, int y)
    {
        if (x >= 0 && x < size && y >= 0 && y < size)
            grid[x, y] = grid[x, y] == 0 ? 1 : 0;
    }
    #endregion

    #region Grid Access & Visuals
    public int GetValue(int x, int y) => grid[x, y];
    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && x < size && y >= 0 && y < size)
            grid[x, y] = value;
    }

    public void UpdateVisuals()
    {
        if (cells == null) return; // grid yoksa çýk
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (cells[x, y] != null) // null kontrolü
                    cells[x, y].SetState(grid[x, y]);
            }
        }
    }

    public int Size => size;
    #endregion

    #region Win Check
    private bool CheckWin()
    {
        int first = grid[0, 0];
        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
                if (grid[x, y] != first)
                    return false;

        return true;
    }
    #endregion

    #region Game Reset
    public void ResetGame()
    {
        // Sahnedeki tüm hücreleri sil
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        // Grid ve cells arraylerini temizle
        grid = null;
        cells = null;

        // Mod ve size sýfýrla
        currentMode = null;
        size = 0;
    }
    #endregion
}