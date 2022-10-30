using MrPigCore;
using MrPigEvents;

public class GameExitButton : MrPigBaseBehaviour
{
   
    public void OnButtonClicked()
    {
        TriggerEvent<GameExitButtonEvent>(new BaseEvent());
    }
}
