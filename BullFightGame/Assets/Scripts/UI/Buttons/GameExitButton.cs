public class GameExitButton : BaseBehaviour
{
   
    public void OnButtonClicked()
    {
        TriggerEvent<GameExitButtonEvent>(new BaseEvent());
    }
}
