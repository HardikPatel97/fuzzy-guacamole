using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public BoardView boardView;
    public LayoutConfig layoutConfig;
    public CardData[] cardPool; // assign all available card data assets

    private GamePresenter presenter;
    private GameModel model;
    private SaveService saveService;

    void Start()
    {
        model = new GameModel();
        saveService = new SaveService();

        var savedData = saveService.LoadGame();
        presenter = new GamePresenter(model, boardView, layoutConfig, cardPool, savedData);
    }

    void OnDestroy()
    {
        presenter?.Dispose();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause && model != null)
            saveService.SaveGame(model.ToSaveData());
    }

    void OnApplicationQuit()
    {
        if (model != null)
            saveService.SaveGame(model.ToSaveData());
    }
}