using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private BoardView boardView;
    [SerializeField] private LayoutConfig layoutConfig;
    [SerializeField] private CardData[] cardPool; // assign all available card data assets
    [SerializeField] private AudioService audioService;
    [SerializeField] private SoundDatabase soundDatabase;

    private GamePresenter presenter;
    private GameModel model;
    private SaveService saveService;

    void Start()
    {
        model = new GameModel();
        saveService = new SaveService();

        var savedData = saveService.LoadGame();
        presenter = new GamePresenter(model, boardView, layoutConfig, cardPool, savedData, audioService);
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