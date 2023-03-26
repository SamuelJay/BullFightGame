using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasController : Controller
{
    [SerializeField] private Button startButton;
    
    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        startButton.onClick.AddListener(StartButtonPressed);
    }

    private void StartButtonPressed()
    {
        TriggerEvent<MainMenuStartButtonEvent>(new MainMenuStartButtonEvent());
    }
}
