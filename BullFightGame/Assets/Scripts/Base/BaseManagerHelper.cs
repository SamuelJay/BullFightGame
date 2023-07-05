using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManagerHelper : BaseBehaviour
{
    //all this has been copied to the appmamnager
   /* [SerializeField] private GameObject eventManagerPrefab;
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
    }*/
}
