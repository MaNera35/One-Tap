using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;

    public void StartEndlessGame()
    {
        EndlessMode mode = new EndlessMode();
        gridManager.SetMode(mode);
        gridManager.GenerateNewLevel(10);
    }

    public void StartTestGame()
    {
        TestMode mode = new TestMode();
        gridManager.SetMode(mode);
        gridManager.GenerateNewLevel(25);

    }

}
