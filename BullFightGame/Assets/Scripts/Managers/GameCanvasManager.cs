using MrPigCore;
using UnityEngine;

public class GameCanvasManager : CanvasManager
{
    [SerializeField]private MrPigBaseBehaviour[] buttons;
    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        foreach (MrPigBaseBehaviour button in buttons)
        {
            button.Setup(baseManagerHelper);
        }
    }
    

}
