using MrPigCore;
using MrPigEvents;

public class MainMenuStartButton : MrPigBaseBehaviour
{
    public void OnButtonClicked()
    {
        TriggerEvent<MainMenuStartButtonEvent>(new BaseEvent());
    }
}
