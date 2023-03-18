using UnityEngine;

public class MainMenuCanvasManager : CanvasManager
{

    [SerializeField] private BaseBehaviour[] buttons;
    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        foreach (BaseBehaviour button in buttons)
        {
            button.Setup(baseManagerHelper);
        }
    }
}
