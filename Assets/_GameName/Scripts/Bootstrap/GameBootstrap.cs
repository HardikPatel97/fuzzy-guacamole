using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    public BoardView boardView;
    public LayoutConfig layoutConfig;
    public CardData[] cardPool; // assign all available card data assets

    private GamePresenter presenter;
    private GameModel model;

    void Start()
    {
        model = new GameModel();
        presenter = new GamePresenter(model, boardView, layoutConfig, cardPool);
    }

    void OnDestroy()
    {
        presenter?.Dispose();
    }
}