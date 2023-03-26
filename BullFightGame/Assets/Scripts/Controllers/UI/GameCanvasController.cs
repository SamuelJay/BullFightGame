using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : Controller
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private ManagerHelper managerHelper => baseManagerHelper as ManagerHelper;
    private SceneLoaderManager sceneLoaderManager => managerHelper.sceneLoaderManager;

    public override void Setup(BaseManagerHelper baseManagerHelper)
    {
        base.Setup(baseManagerHelper);
        exitButton.onClick.AddListener(OnExitButton);
    }

    public void ShowGameOverPanel(string losingPlayerID) 
    {
        int losingPlayerNumber = int.Parse(losingPlayerID);

        gameOverPanel.SetActive(true);

        if (losingPlayerNumber is 1) gameOverText.text =$"You Lose!";
        else gameOverText.text = $"You Win!";
    }

    public void HideGameOverPanel() 
    {
        gameOverPanel.SetActive(false);
    }

    private void OnExitButton()
    {
        sceneLoaderManager.LoadMainMenuScene();
    }
}
