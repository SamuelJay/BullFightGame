public class MainMenuStartButton : BaseBehaviour
{
    public void OnButtonClicked()
    {
        TriggerEvent<MainMenuStartButtonEvent>(new BaseEvent());
    }
}
