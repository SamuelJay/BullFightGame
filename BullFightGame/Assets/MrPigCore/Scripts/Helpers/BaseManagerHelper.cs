using MrPigCore;
using MrPigEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManagerHelper : MrPigBaseBehaviour
{
    [SerializeField] private GameObject eventManagerPrefab;
    private GameObject eventManagerObject;
    public EventManager eventManager
    {
        get;
        private set;
    }

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        eventManagerObject = Instantiate(eventManagerPrefab);
        DontDestroyOnLoad(eventManagerObject);
        eventManager = eventManagerObject.GetComponent<EventManager>();
        eventManager.Setup(this);
    }
}
