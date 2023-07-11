using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasController : Controller
{
    [SerializeField] private Button startButton;
    
    public override void Setup(AppManager appManager)
    {
        base.Setup(appManager);
        startButton.onClick.AddListener(StartButtonPressed);
    }

    private void StartButtonPressed()
    {
        TriggerEvent<MainMenuStartButtonEvent>(new MainMenuStartButtonEvent());
    }
}
