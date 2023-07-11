using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    [SerializeField] private GameObject mainMenuCanvasPrefab;
    private GameObject mainMenuCanvasObject;
    private MainMenuCanvasController mainMenuCanvasController;
    [SerializeField] private GameObject gameCanvasPrefab;
    private GameObject gameCanvasObject;
    private GameCanvasController gameCanvasController;

    public override void Setup(AppManager appManager)
    {
        base.Setup(appManager);
    }

    public void SetupMainMenuUI()
    {
        mainMenuCanvasObject = Instantiate(mainMenuCanvasPrefab);
        mainMenuCanvasController = mainMenuCanvasObject.GetComponent<MainMenuCanvasController>();
        mainMenuCanvasController.Setup(appManager);
    }

    public void SetupGameUI()
    {
        gameCanvasObject = Instantiate(gameCanvasPrefab);
        gameCanvasController = gameCanvasObject.GetComponent<GameCanvasController>();
        gameCanvasController.Setup(appManager);
    }

    public void ShowGameOverPanel(string losingPlayerID)
    {
        gameCanvasController.ShowGameOverPanel(losingPlayerID);
    }

    public void HideGameOverPanel()
    {
        gameCanvasController.HideGameOverPanel();
    }
}
