using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHelper : BaseManagerHelper
{
  /*  #region Don't Destroy On Load
    [SerializeField] private GameObject sceneLoaderManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;
    [SerializeField] private GameObject inputManagerPrefab;
    
    private GameObject sceneLoaderManagerObject;
    private GameObject uiManagerObject;
    private GameObject inputManagerObject;
  *//*  public SceneLoaderManager sceneLoaderManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public InputManager inputManager { get; private set; }*//*
   
    #endregion Don't Destroy On Load

    #region Main Menu
    [SerializeField] private GameObject mainMenuManagerPrefab;
    private GameObject mainMenuManagerObject;
   // public MainMenuManager mainMenuManager { get; private set; }
    #endregion Main Menu

    #region Game
    [SerializeField] private GameObject gameManagerPrefab;
    private GameObject gameManagerObject;
    public GameManager gameManager { get; private set; }
    #endregion Game
    public void Setup(BaseManagerHelper baseManagerHelperIn, AppManager appManagerIn)
    {
        base.Setup(appManager);
        sceneLoaderManagerObject = Instantiate(sceneLoaderManagerPrefab);
        uiManagerObject = Instantiate(uiManagerPrefab);
        
    *//*    sceneLoaderManager = sceneLoaderManagerObject.GetComponent<SceneLoaderManager>();
        uiManager = uiManagerObject.GetComponent<UIManager>();*//*
        
        DontDestroyOnLoad(sceneLoaderManagerObject);
        DontDestroyOnLoad(uiManagerObject);
        
        sceneLoaderManager.Setup(this);
        uiManager.Setup(this);
    }
    public void MainMenuSetup() 
    {
        mainMenuManagerObject = Instantiate(mainMenuManagerPrefab);
       // mainMenuManager = mainMenuManagerObject.GetComponent<MainMenuManager>();
        mainMenuManager.Setup(this);
        uiManager.SetupMainMenuUI();
    }
    public void GameSetup()
    {
        gameManagerObject = Instantiate(gameManagerPrefab);
        inputManagerObject = Instantiate(inputManagerPrefab);
        
  *//*      gameManager = gameManagerObject.GetComponent<GameManager>();
        inputManager = inputManagerObject.GetComponent<InputManager>();*//*
        
        gameManager.Setup(this);
        inputManager.Setup(this);
        uiManager.SetupGameUI();
    }
*/
}
