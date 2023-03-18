using System;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public BaseManagerHelper baseManagerHelper
    {
        get;
        private set;
    }
    private EventManager eventManager
    {
        get
        {
            return baseManagerHelper.eventManager;
        }
    }
    public virtual void Setup(BaseManagerHelper baseManagerHelper)
    {
        this.baseManagerHelper = baseManagerHelper;
    }

    public void TriggerEvent<T>(BaseEvent eventArgs)
    {
        eventManager.Trigger<T>(eventArgs);
    }
    public void StartListeningToEvent<T>(EventHandler callBack)
    {
        eventManager.StartListening<T>(callBack);
    }
    public void StopListeningToEvent<T>(EventHandler callBack)
    {
        eventManager.StopListening<T>(callBack);
    }
}
