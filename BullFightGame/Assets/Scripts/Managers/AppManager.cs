using System;
using UnityEngine;

public class AppManager : Manager
{
    public EventManager eventManager { get; private set;}
    public SceneLoaderManager sceneLoaderManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public InputManager inputManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }
    public GameManager gameManager { get; private set; }


    [SerializeField] private EventManager eventManagerPrefab;
    [SerializeField] private SceneLoaderManager sceneLoaderManagerPrefab;
    [SerializeField] private UIManager uiManagerPrefab;
    [SerializeField] private InputManager inputManagerPrefab;
    [SerializeField] private MainMenuManager mainMenuManagerPrefab;
    [SerializeField] private GameManager gameManagerPrefab;


    private void Awake()
    {
        Setup(this);
    }

    public override void Setup(AppManager appManager)
    {      
        base.Setup(appManager);

        eventManager = Instantiate(eventManagerPrefab);
        sceneLoaderManager = Instantiate(sceneLoaderManagerPrefab);
        uiManager = Instantiate(uiManagerPrefab);
        inputManager = Instantiate(inputManagerPrefab);
        mainMenuManager = Instantiate(mainMenuManagerPrefab);
        gameManager = Instantiate(gameManagerPrefab);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(eventManager);
        DontDestroyOnLoad(sceneLoaderManager);
        DontDestroyOnLoad(uiManager);
        DontDestroyOnLoad(inputManager);
        DontDestroyOnLoad(mainMenuManager);
        DontDestroyOnLoad(gameManager);

        eventManager.Setup(this);
        sceneLoaderManager.Setup(this);
        uiManager.Setup(this);
        inputManager.Setup(this);
        mainMenuManager.Setup(this);
        gameManager.Setup(this);


        sceneLoaderManager.LoadMainMenuScene();


        StartListeningToEvent<MainMenuSceneLoadedEvent>(OnMainMenuSceneLoadedEvent);
        StartListeningToEvent<GameSceneLoadedEvent>(OnGameSceneLoadedEvent);
        StartListeningToEvent<MainMenuStartButtonEvent>(OnMainMenuStartButtonEvent);
    }

    private void OnMainMenuStartButtonEvent(object sender, EventArgs e)
    {
        sceneLoaderManager.LoadGameScene();
    }

    private void OnMainMenuSceneLoadedEvent(object sender, EventArgs e)
    {
        appManager.MainMenuSetup();
    }

    private void OnGameSceneLoadedEvent(object sender, EventArgs e)
    {
       appManager.GameSetup();
    }
    private void OnDestroy()
    {
        StopListeningToEvent<MainMenuSceneLoadedEvent>(OnMainMenuSceneLoadedEvent);
        StopListeningToEvent<GameSceneLoadedEvent>(OnGameSceneLoadedEvent);
        StopListeningToEvent<MainMenuStartButtonEvent>(OnMainMenuStartButtonEvent);
    }

    public void MainMenuSetup() {
        mainMenuManager = Instantiate(mainMenuManagerPrefab);
        mainMenuManager.Setup(this);
    }

    public void GameSetup() {
        gameManager = Instantiate(gameManagerPrefab);
        gameManager.Setup(this);
    }
}
