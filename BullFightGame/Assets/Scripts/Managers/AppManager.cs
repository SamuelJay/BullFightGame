using System;
using UnityEngine;

public class AppManager : Manager
{
    [SerializeField] private GameObject managerHelperPrefab;
    private GameObject managerHelperObject;
    

    private ManagerHelper managerHelper;
    
    private SceneLoaderManager sceneLoaderManager 
    {
        get {
            return managerHelper.sceneLoaderManager;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        managerHelperObject = Instantiate(managerHelperPrefab);
        DontDestroyOnLoad(managerHelperObject);
        managerHelper = managerHelperObject.GetComponent<ManagerHelper>();
        managerHelper.Setup(managerHelper, this);
        Setup(managerHelper);
    }

    public override void Setup(BaseManagerHelper baseManagerHelperIn)
    {
        base.Setup(baseManagerHelperIn);
        
        sceneLoaderManager.LoadMainMenuScene();

        StartListeningToEvent<MainMenuSceneLoadedEvent>(OnMainMenuSceneLoadedEvent);
        StartListeningToEvent<GameSceneLoadedEvent>(OnGameSceneLoadedEvent);
        StartListeningToEvent<MainMenuStartButtonEvent>(OnMainMenuStartButtonEvent);
        StartListeningToEvent<GameExitButtonEvent>(OnGameExitButtonEvent);
    }

    private void OnMainMenuStartButtonEvent(object sender, EventArgs e)
    {
        sceneLoaderManager.LoadGameScene();
    }
    private void OnGameExitButtonEvent(object sender, EventArgs e)
    {
        sceneLoaderManager.LoadMainMenuScene();
    }

    private void OnMainMenuSceneLoadedEvent(object sender, EventArgs e)
    {
        managerHelper.MainMenuSetup();
    }

    private void OnGameSceneLoadedEvent(object sender, EventArgs e)
    {
        managerHelper.GameSetup();
    }
    private void OnDestroy()
    {
        StopListeningToEvent<MainMenuSceneLoadedEvent>(OnMainMenuSceneLoadedEvent);
        StopListeningToEvent<GameSceneLoadedEvent>(OnGameSceneLoadedEvent);
        StopListeningToEvent<MainMenuStartButtonEvent>(OnMainMenuStartButtonEvent);
        StopListeningToEvent<GameExitButtonEvent>(OnGameExitButtonEvent);
    }
}
