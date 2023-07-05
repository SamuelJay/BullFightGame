using System;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    private EventManager eventManager => appManager.eventManager;

    public AppManager appManager { get; private set; }
    public virtual void Setup(AppManager appManager) {
        this.appManager = appManager;
    }
   
    public void StartListeningToEvent<T>(EventHandler callBack)
    {
        eventManager.StartListening<T>(callBack);
    }
    public void StopListeningToEvent<T>(EventHandler callBack)
    {
        eventManager.StopListening<T>(callBack);
    }
    public void TriggerEvent<T>(BaseEvent eventArgs)
    {
        eventManager.Trigger<T>(eventArgs);
    }
}
